# Projeto Voluntários na Escola

## Visão Administrador  
  * Usuário: admin / Senha:102030 

## Visão Escola/Diretor  
  * Usuário: escola01 / Senha: 102030 (Diretor Aprovado) 
  * Usuário: escola02 / Senha: 102030 (Diretor em aprovação) 

## Visão Supervisor

## Visão Voluntário 
  * Usuário: voluntario01 / Senha: 102030 
  * Tópico Teste
 
 
## Etapas para compilar e rodar arquivos 
 
1. Instalar IIS7 e configurar para rodar aplicações .net
2. Instalar Visual Studio 2015 ou superior
3. Instalar o SQL Server 2008 ou superior
4. Abrir Visual Studio como administrador
5. Procurar o arquivo da solução dentro da pasta .sln
6. Modificar a conexão para o banco local
7. Realizar a complicação da solução
8. Rodar primeiro a aplicação de Serviço (VoluntariosNaEscola.AppService.WebApi)
9. Editar o arquivo VoluntariosNaEscola.Presentation.WebAngular/Angular/app.base.js
  * Atribuir o endereço local do serviço para a variável HostHttp  
10. Após rodar o projeto web (VoluntariosNaEscola.Presentation.WebAngular)
11. Administrador - Usuário: Admin Senha : 102030 
