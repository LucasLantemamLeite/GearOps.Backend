# GearOps.Backend 🚀

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=asp.net&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![Postgres](https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white)
![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
![LinkedIn](https://img.shields.io/badge/linkedin-%230077B5.svg?style=for-the-badge&logo=linkedin&logoColor=white)

---

O **GearOps.Backend** é a parte do servidor da aplicação **GearOps**, responsável por manipular o banco de dados através de rotas **API RESTful**. Foi desenvolvido utilizando **ASP.NET 8** 🖥️.

---

### 📜 Origem do Projeto

O projeto teve como ponto de partida um **relatório em Power BI** do meu antigo posto de trabalho.  
Por limitações da plataforma, decidi criar o **GearOps** utilizando uma abordagem mais programática 💻.

---

### 🗄️ Banco de Dados

- Utiliza **PostgreSQL** 🐘 devido à sua **performance e flexibilidade**.
- Para operações de CRUD, o projeto utiliza **Entity Framework** 🔗, facilitando o trabalho com o banco sem precisar escrever queries manualmente com Dapper.

---

### 🏗️ Arquitetura

- O projeto segue o padrão **MVC** (Model-View-Controller) 🧩.
- Esta é a **versão 1.0**, focada em criar um **MVP** antes de evoluir para uma versão 2.0 mais completa 🌱.

---

### 📂 Estrutura do projeto

```
📂 GearOps.Backend
 ┣ 📂 GearOps.Api
 ┣  ┣ 📂 Configurations
 ┣  ┣ 📂 Controllers
 ┣  ┣ 📂 Data
 ┣  ┣  ┣ 📂 Context
 ┣  ┣  ┗ 📂 Mapping
 ┣  ┣ 📂 DTOs
 ┣  ┣ 📂 Enums
 ┣  ┣ 📂 Migrations
 ┣  ┣ 📂 Models
 ┣  ┣ 📂 Properties
 ┣  ┣ 📄 appsettings.Development.json
 ┣  ┣ 📄 appsettings.json
 ┣  ┣ 📄 GearOps.Api.csproj
 ┣  ┗ 📝 Program.cs
 ┣ 📄 .gitignore
 ┣ 📄 dockerfile.bd
 ┣ 📄 dockerfile.ef
 ┣ 📄 GearOpsSolution.sln
 ┗ 📄 ReadMe.md
```

---

### ⚡ Comunicação em Tempo Real

- Utiliza **SignalR** 🔄 para comunicação em tempo real, permitindo que o servidor atualize a interface do frontend de forma instantânea.

---

### 🐳 Docker

O projeto possui dois arquivos **Dockerfile** para testes em redes privadas, facilitando a execução e isolamento do ambiente:

- 1. O **dockerfile.bd** é responsável por compilar e rodar a aplicação do ASP.NET.

- 2. O **dockerfile.ef** é responsável por aplicação as migrações do banco de dados do PostGres que só é executado com o docker-compose.

---

### 🚀 Rodar container Docker - dockerfile.bd

1. Clonar esse Repositório:

   ```
   git clone https://github.com/LucasLantemamLeite/GearOps.Backend.git
   ```

2. Compilar a imagem:

   ```
   docker build -f dockerfile.bd -t gearops-backend .
   ```

3. Rodar o container em ip privado:

   ```
   docker run -d -p 8080:8080 --name gearops-server gearops-backend
   ```

4. Verificar se está rodando:
   ```
   http://localhost:5059/v1/health -> verifica se está rodando localmente (localhost)
   http://'ip-da-máquina':8080/v1/health -> verifica se está rodando em rede privada
   ```

---

### 🚀 Rodar o container via docker-compose

1. Clonar o Repositório do Frontend da aplicação

   ```
   git clone https://github.com/LucasLantemamLeite/GearOps.Frontend.git
   ```

2. Criar um arquivo **docker-compose.yml** na raiz da aplicação (fora da pasta do GearOps.Backend)

3. Aplicação os seguintes serviços no arquivo do docker-compose:

   ```yml
   services:
     postgres:
       image: postgres:16-alpine
       container_name: postgres_db
       restart: always
       networks:
         - gearops_networks
       environment:
         POSTGRES_USER: postgres
         POSTGRES_PASSWORD: postgres
         POSTGRES_DB: GearOpsDb
       ports:
         - "5432:5432"
       volumes:
         - postgres_data:/var/lib/postgresql/data

     backend:
       container_name: gearops-server
       build:
         context: ./GearOps.Backend
         dockerfile: dockerfile.bd
       networks:
         - gearops_networks
       environment:
         - ConnectionStrings__DefaultConnection=Host=postgres;Database=GearOpsDb;Username=postgres;Password=postgres
       ports:
         - "8080:8080"
       depends_on:
         - postgres

     frontend:
       build: ./GearOps.frontend
       ports:
         - "3000:3000"
       depends_on:
         - backend
       networks:
         - gearops_networks

     migrations:
       build:
         context: ./GearOps.Backend
         dockerfile: dockerfile.ef
       depends_on:
         - postgres
       networks:
         - gearops_networks
       environment:
         - ConnectionStrings__DefaultConnection=Host=postgres;Database=GearOpsDb;Username=postgres;Password=postgres
       command: dotnet ef database update

   volumes:
     postgres_data:

   networks:
     gearops_networks:
       driver: bridge
   ```

4. Comando para rodar a aplicação:

   ```
   docker-compose up -> Para rodar com logs do container
   docker-compose up -d -> Para rodar em segundo plano
   ```

5. Substituir a política de Cors da aplicação (backend) para o ip da máquina caso queria testar em rede privada

   - Arquivo: [`GearOps.Backend/GearOps.Api/Configurations/Builder/BuilderConfig.cs`](./GearOps.Api/Configurations/Builder/BuilderConfig.cs)

6. Alterar a baseUrl do axios nos services e o HubConnectionBuilder na seção de devices

   - Arquivo baseUrl: [`GearOps.Frontend/app/services/requests/api.ts`](../GearOps.Frontend/app/services/requests/api.ts)

   - Arquivo signalR: [`GearOps.Frontend/app/services/signalR/connectionHub.ts`](../GearOps.Frontend/app/services/signalR/connectionHub.ts)
