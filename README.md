

Há dois códigos em duas pastas, um é o cliente UDP e o outro é o servidor UDP.

A linguagem utilizada é .NET C# 7.

O banco de dados utilizado é o SQL Server local.<br>
Talvez seja necessário configurar a senha e o login da connection string no arquivo UDPServe/UDPServe/handlers/SaveData.cs. Usado: "Server=localhost\SQLEXPRESS01;DataBase=DevStatus;Integrated Security=True; TrustServerCertificate=True".<br>
O banco de dados é criado ao iniciar o UDPServer (dotnet run) caso ainda não exista. Para executar esse comando, é necessário estar na pasta UDPServe/UDPServe<br>.

O UDPClient fornece dados aleatórios automaticamente para o UDPServer.<br>
É necessário configurar o IP local no Program.cs do UDPClient/Program.cs.<br>
A porta configurada tanto no UDPClient quanto no UDPServer é a 11000, então o firewall deve permitir acesso a essa porta.<br>
Ao iniciar o UDPClient, dados serão enviados a cada 5 segundos. Para finalizar a aplicação, basta pressionar Enter no console. Execute o dotnet run dentro da pasta UDPClient/.<br>

Os arquivos em formato JSON serão salvos na pasta 'json' dentro da UDPServer. Caso a pasta ainda não tenha sido criada, o programa a criará automaticamente. Eles são nomeados com o ID dos dados, por exemplo: 123.json.

***************

Versão do código executado na AWS, utilizando o EC2 como servidor UDP, salvando os arquivos JSON em um bucket S3 e registrando os dados no RDS SQL Server.

https://github.com/niltongc/dotnet-AWS-EC2-UDP-Server

***************
