Há dois códigos em duas pastas, um é o UDP client e o outro é o UDP server.

O banco de dados utilizado é o SQL Server local.<br>
A linguagem utilizada é .NET C#.<br>
O UDPClient fornece dados aleatórios automaticamente para o UDPServer.<br>
É necessário configurar o IP local no Program.cs do UDPClient.<br>
A porta configurada tanto no UDPClient quanto no UDPServer é a 11000.<br>
O banco de dados é criado ao iniciar o UDPServer caso ainda não exista (dotnet run).<br>
Ao iniciar o UDPClient, dados serão enviados a cada 5 segundos. Para finalizar a aplicação, basta pressionar Enter no console.<br>
Os arquivos em formato JSON serão salvos na pasta 'json' dentro da UDPServer. Eles são nomeados com o ID dos dados, por exemplo: 123.json.