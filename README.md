# assessment
O projeto deve ser dividido em duas partes.

#########################################################################
PRIMEIRA PARTE
#########################################################################

Desenvolver uma aplicação em python que sirva de socket UDP para recepção de dados

O dados recebidos devem possuir o seguinte formato

>DATAtype,protocolo,yymmddhhmmss,status;ID=id<

exemplos: 
>DATA1,66,220918235757,1;ID=123<
>DATA2,66,220921230008,0;ID=456<

Desenvolver uma função que analise o comando de entrada e faça o parse dos dados salvando em um JSON com o seguinte formato:

{“type”: 1, “protocolo”: 66, “utc”: “2022-09-18 23:57:57”, “status”: 0, “id”: “123”}

Criar uma base de dados local contendo uma única tabela para receber esses dados. A tabela deve se chamar dev_status e conter as seguintes colunas:

type int
protocolo int
utc datetime
status int
id varchar

Usar o bando de preferencia!

#########################################################################
SEGUNDA PARTE
#########################################################################

Desenvolver uma “simulador” de comandos. Ele deve gerar comandos de forma aleatória, mas dentro do padrão definido

>DATAtype,protocolo,yymmddhhmmss,status;ID=id<

seguindo as regras de:

type só pode ser 1 ou 2
protocolo só pode ser 66, 67 ou 68
uma data válida
status só pode ser 0 ou 1
id deve conter somente 3 caracteres
Quando executado o simulador deve ficar em execução até que seja interrompido 
Ele deve se conectar ao processo do socket, e a cada 1 segunda enviar um dado 

#########################################################################

Descrever passo a passo como o processo deve ser iniciado e executado.

BOA SORTE!
