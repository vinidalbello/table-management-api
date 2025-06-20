# 🍽️ TableManagement – Backend

Este projeto é uma API ASP.NET Core para gestão de mesas. Siga os passos abaixo para subir a aplicação **e** o banco de dados localmente sem complicação.

---

## 1️⃣ Pré-requisitos

* **.NET 8 SDK** – https://dotnet.microsoft.com/download
* **Docker** (opcional, mas recomendado para subir o PostgreSQL rapidamente) – https://docs.docker.com/get-docker/

---

## 2️⃣ Configurando o banco

### 📦 Usando Docker (recomendado)
Execute no terminal (ajuste portas/usuário se quiser):
```bash
# Cria e inicia um container PostgreSQL 16
# DB: tablemanagement | usuário: tableuser | senha: changeme

docker run \
  --name tablemanagement-postgres \
  -e POSTGRES_USER=tableuser \
  -e POSTGRES_PASSWORD=changeme \
  -e POSTGRES_DB=tablemanagement \
  -p 5432:5432 \
  -d postgres:16
```

> Já tem um PostgreSQL instalado? Pule este passo e use sua instância.

---

## 3️⃣ Variáveis de ambiente

A API lê as credenciais via **variáveis de ambiente** (ou arquivo `.env`).

Crie um arquivo `.env` na raiz do *backend* (mesmo nível de `Program.cs`) com o seguinte conteúdo ⬇️ **e troque os valores** conforme sua configuração:
```env
DB_HOST=localhost
DB_PORT=5432
DB_DATABASE=tablemanagement
DB_USER=tableuser
DB_PASSWORD=changeme
```

⚠️ **Nunca** faça commit deste arquivo contendo dados sensíveis.

---

## 4️⃣ Restaurando dependências & migrações

```bash
# Na pasta backend
cd backend

# Restaura pacotes NuGet
 dotnet restore

# Aplica as migrações do Entity Framework Core (cria as tabelas)
dotnet ef database update
```

---

## 5️⃣ Rodando a API 🚀

```bash
# Ainda na pasta backend
 dotnet watch run    # Hot reload 🔥
```

Se tudo der certo, você verá algo como:
```
info: Now listening on: https://localhost:5001
```

Abra `https://localhost:5001/swagger` para testar os endpoints via Swagger UI.

---

## 6️⃣ Encerrando

Para parar tudo:
```bash
# Interrompe a API (Ctrl+C no terminal onde ela está rodando)

# Se usou Docker para o Postgres
 docker stop tablemanagement-postgres && docker rm tablemanagement-postgres
```

---

💡 Dúvidas ou sugestões? Abra uma *issue* ou fale conosco!
