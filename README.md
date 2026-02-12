# HelloMotors
Web API Rest para gerenciar o inventário de veículos, dados de proprietários e comissões de vendedores. Desenvolvida como projeto final do curso de Desenvolvimento .NET e SQL Server.

## Instruções:

- Execute o comando *dotnet ef database update* para a criação do DB local.
- Crie o appsettings.json e configure a connection string para a conexão com o servidor.

    
    ```json
    {
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "ConnectionStrings": {
        "DefaultConnection": "Server=<NOME>,<PORTA>;Database=HelloMotorsDB;User Id=<USUARIO>;Password=<SENHA>;TrustServerCertificate=true;"
      },
      "AllowedHosts": "*"
    }
    ```
    

### Sugestões de Inserções:

Proprietário

```json
{
  "nome": "João Almeida",
  "cpfCnpj": "12345678910",
  "endereco": "Rua Almirante, n 42",
  "email": "joao@gmail.com",
  "telefone": "41995543023",
  "dadosPessoais": "Pessoa Física"
}
```

Veículo

```json
{
  "chassi": "3dEj3DcclH5zx0941",
  "modelo": "Brasília",
  "versaoSistema": "1.2",
  "ano": 1980,
  "cor": "Amarelo",
  "quilometragem": 12,
  "valor": 55000,
  "acessorios": "Bancos de couro, rádio embutido"
}
```

Vendedor

```json
{
  "nome": "Fábio Dias",
  "salarioBase": 2500
}
```

Venda:

```json
{
  "dataVenda": "2026-02-11T02:58:29.380Z",
  "valorFinal": 55000,
  "idVendedor": 1,
  "idVeiculo": 1,
  "idProprietario": 1
}
```

### Modelagem:

![image.png](attachment:b822b675-c07a-4b55-a202-1d39470b0f31:image.png)
