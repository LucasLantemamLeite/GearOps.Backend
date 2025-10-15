# GearOps.Backend 🚀

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
 ┣ 📄 dockerfile
 ┣ 📄 GearOpsSolution.sln
 ┗ 📄 ReadMe.md
```

---

### ⚡ Comunicação em Tempo Real

- Utiliza **SignalR** 🔄 para comunicação em tempo real, permitindo que o servidor atualize a interface do frontend de forma instantânea.

---

### 🐳 Docker

- O projeto possui um **Dockerfile** para testes em redes privadas, facilitando a execução e isolamento do ambiente.

---

### 🚀 Rodar container Docker - Dockerfile

1. Compilar a imagem:

   ```
   docker build -t gearops-backend
   ```

2. Rodar o container em ip privado:

   ```
   docker run -d -p 8080:8080 --name gearops-server gearops-backend
   ```

3. Verificar se está rodando:
   ```
   http://localhost/v1/health -> verifica se está rodando localmente (localhost)
   http://'ip-da-máquina'/v1/health -> verifica se está rodando em rede privada
   ```

---

### 📖 Wiki

Para mais informações, consulte a [Wiki do projeto](https://github.com/LucasLantemamLeite/GearOps.Backend/wiki).
