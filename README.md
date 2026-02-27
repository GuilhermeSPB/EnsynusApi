
# Ensynus API

API REST desenvolvida em **ASP.NET Core (C#)** para gerenciamento de alunos, professores, turmas, aulas e autenticação, incluindo sistema de login, registro, JWT e confirmação de e-mail.

---

## Tecnologias

- ASP.NET Core  
- Entity Framework Core  
- MySQL  
- JWT Authentication  
- SMTP (Envio de e-mail)  
- Clean Architecture (Services + Controllers)  
- React (Frontend integrado separadamente)  

---

## Estrutura do Projeto

```text
ENSYNUSAPI
├── Controllers        # Controladores e rotas da API
├── Data               # Contexto do banco de dados
├── Dtos               # Data Transfer Objects
│   ├── Aluno
│   ├── Auth
│   ├── Ingresso
│   ├── Professor
│   └── Turma
├── Middleware         # Middlewares de requisição
├── Migrations         # Migrações do Entity Framework
├── Models             # Entidades do domínio
├── Properties         # Configurações do projeto
├── Repository         # Camada de persistência
│   ├── Aluno
│   ├── Ingresso
│   ├── Professor
│   └── Turma
└── Service            # Camada de regras de negócio
    ├── Auth
    ├── Email
    └── Token
```
## Configuração

Passo a passo para executar a API.

 **Clone o projeto**

```bash 
git clone https://github.com/GuilhermeSPB/EnsynusApi.git
```

 **Configure o banco de dados**

```json
"ConnectionStrings": {
"DefaultConnection":
"Server=localhost;Port=3030;Database=ensynus;Uid=root;Pwd=root;SslMode=None;AllowPublicKeyRetrieval=True;"}
```
 **Configure o JWT**

 ```json
"Jwt": {
  "Key": "SUA_CHAVE",
  "Issuer": "EnsynusApi",
  "Audience": "EnsynuFrontEnd"
}
```

**Configure o SMTP (email)**
 ```json
"Email": {
  "Smtp": "smtp.gmail.com",
  "Username": "SEU_EMAIL",
  "User": "SEU_EMAIL",
  "Password": "senha-ou-app-password"
}
```

**Execute as migrations**
 ```bash
dotnet ef database update
```

**Execute a API**
 ```bash
dotnet run
```


## Testes

Você pode testar usando:
* Postman
* Insomnia
* Swagger

## Progresso
Atualmente o projeto se encontra por volta de  70% concluído. Em caso de sugestões contatar **Guiseredko@gmail.com**

## Autor
Projeto desenvolvido por **Guilherme Lima Seredko**

