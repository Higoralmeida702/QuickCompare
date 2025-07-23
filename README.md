🚀 Descrição do Projeto:
Projeto acadêmico full-stack desenvolvido para comparar especificações técnicas de celulares e notebooks. A solução oferece uma comparação detalhada dos produtos cadastrados, facilitando a escolha do melhor dispositivo conforme critérios técnicos.

Funcionalidades Principais
📱 Exibição detalhada de produtos com suas especificações técnicas, incluindo características como processador, memória, armazenamento, tela e conectividade.

⚖️ Comparação lado a lado de dispositivos, com algoritmo que avalia e pontua critérios técnicos para destacar qual aparelho é superior em cada aspecto (ex.: mais RAM, bateria maior, suporte a 5G).

🧰 Gerenciamento completo (CRUD) de produtos via backend robusto, garantindo integridade e consistência das informações utilizadas nas comparações.

Tecnologias Utilizadas
Front-End:
⚛️ React.js

Back-End:
🖥️ ASP.NET Core Web API (.NET)
🐬 MySQL como banco de dados
📡 API REST para gerenciamento e consulta dos dispositivos

Documentação e Testes:
📘 Swagger para documentação interativa e testes dos endpoints

Desenvolvimento e Aprendizado
Neste projeto, apliquei e aprofundei conhecimentos em:
Arquitetura limpa (Clean Architecture) para organização e desacoplamento do código
Desenvolvimento orientado a domínio (DDD), com entidades que encapsulam regras e validações do negócio
Criação de algoritmos de comparação técnica, analisando múltiplos critérios e gerando resultados claros e objetivos
Integração frontend/backend para filtros dinâmicos e interface responsiva
Documentação clara e testes via Swagger para facilitar uso e futuras integrações

##Como Executar o Projeto

## Como Executar o Projeto

## 1. Clone este repositório:
git clone https://github.com/Higoralmeida702/QuickCompare

## 2. Navegue até a pasta do projeto:
cd QuickCompare

## 3. Abra o projeto no Visual Studio ou na sua IDE de preferência.

## 4. Restaure as dependências:
cd .\Backend\
dotnet restore

## 5. Crie a migration e aplique no banco:
cd .\QuickCompare.Api\
dotnet ef migrations add InitialCreate --startup-project ..\QuickCompare.Api\
dotnet ef database update --startup-project ..\QuickCompare.Api\

## 5. Execute a aplicação: 
cd ..\QuickCompare.Api\
dotnet run

## 6. Acesse a documentação da API no Swagger

## Para acesso do front end:
## 1. Abra um novo terminal (separado do backend), navegue até a pasta do frontend e instale as dependências:
cd .\FrontEnd\
npm i

## 2. Execute a aplicação react:
npm run dev
 
