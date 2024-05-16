# RZN MICRO Project

### [`Documentation`](https://github.com/cleberspirlandeli/rzn-micro/blob/main/Diagrams/MicroRZN-FlowApplication-API%20Applications.drawio.svg)

<br />

### [`Microservices`](https://github.com/cleberspirlandeli/rzn-micro)

<br />

### [`Lambda`](https://github.com/cleberspirlandeli/rzn-micro-lambda)


<br />

#

<br />

Objective:
- .NET Core `7.0` and .NET Core `8.0`.
- Create a base structure, separating responsibilities based on `Domain Driven Design (DDD)`.
- Create a base structure, separating responsibilities based on `Event-Drive Architecture`.
- Create a relational database to receive the data using `AWS RDS MySQL`.
- Create a non-relational database to receive requests read-only using `AWS DynamoDB`.
- Create a message broker using `AWS SQS`.
- Create security credentials and keys using `AWS Systems Manager`.
- Create responsibilities separation and synchronize databases with `AWS Lambda`.
- Create a bucket to store image uploads to `AWS S3`.
- API documentation using `Swagger`.
- Use `AutoMapper`.
- Validation of business rules, classes, and `Request` and `Response` with `FluentValidation`.
- Capturing information for monitoring the API using `Prometheus`
- Automated tests with `Mock` and `AutoMock`.
- TODO - Integration with another API using `HTTP`
- TODO - Integration with another API using `GRPc`
- TODO - Presentation of monitoring information in graphs with `Grafana`
- TODO - Deploy the application in `ECS` on `AWS`
