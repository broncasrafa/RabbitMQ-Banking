# RabbitMQ-Banking

Projeto para praticas na utilização de RabbitMQ com o .NET 6 e Microserviços.

![RabbitMQ](https://img.shields.io/badge/rabbitmq-%23FF6600.svg?&style=for-the-badge&logo=rabbitmq&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)
![Csharp](https://img.shields.io/badge/csharp-019733?&style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET6-512BD4?logo=.net&logoColor=ffffff&style=for-the-badge)
![Visual Studio](https://img.shields.io/badge/VisualStudio-6C33AF?logo=visual%20studio&style=for-the-badge)

## Features
O projeto contempla a seguinte arquitetura e ferramentas:

![Alt text](https://rsfranciscostorage.blob.core.windows.net/randomfiles/GettingStartedMicroservicesRabbitMQ.png)


A ideia por tras dessa pratica é a utilização de microserviços usando um Event Bus que no caso é o RabbitMQ Event Bus
para publicar eventos e se inscrever a esses eventos.

- [Presentation] (qualquer aplicação cliente "web, mobile, desktop, etc") pode enviar uma chamada/requisição HTTP para um 
dos microserviços qualquer que tem seu proprio sistema de backend com um banco de dados SQL, podendo estar containerizado ou
no seu proprio servidor e ele é separado dos demais microserviços.

- [MessageSender] o Microserviço obtem uma requisição de um desses aplicativos do lado cliente, o microserviço usa um Event Bus interno para publicar uma mensagem para um fila que esta dentro do RabbitMQ Server. Esses microserviços podem armazenar algumas informações ou obter algumas informações do banco de dados, seu próprio banco de dados dedicado a esse micro serviço. 
E então o Event bus irá publicar uma mensagem para o servidor do RabbitMQ

- as mensagems ficam nessa fila até que alguém venha busca-las ou alguma aplicação que esteja inscrita nessa fila as consuma.

- [MessageReceivers] podemos ter varios outros microserviços que podem se inscrever em diferentes eventos na fila. Quando eles
se inscrevem nessa filas, são chamados de receptores de mensagens ou assinantes (subscribers).

- O EventBus está cuidando (handling) de todas as nossas publicações e assinaturas para nós, ou seja, a orquestração das várias mensagens e para onde elas vão, e onde são recebidas, como são tratadas.

#### Development
- o projeto de dominio direciona todas as entidades e os objetos necessarios para o Event bus ou RabbitMQ Bus
- é aplicado o padrão de CQRS (Command Query Responsability Segregation) usando o Mediator para todos os eventos que serão publicados e inscritos. Ele enviará comandos para varios lugares através do Event bus podendo publicar qualquer tipo de evento.
- e os services publicam os eventos e se inscrevem em eventos.