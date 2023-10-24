-- Script gerado baseado nos mapeamentos das entidades e seus relacionamentos no EntityFramework.
-- É possível gerar o script usando migrations, mas será necessário inserir os dados de estado na mão mesmo, então recomento rodar esse script.
CREATE DATABASE [GtiTesteBancoDadosTeste]
GO

USE [GtiTesteBancoDadosTeste]
GO

CREATE TABLE [dbo].[Cliente] (
    [Id] [uniqueidentifier] NOT NULL,
    [Cpf] [varchar](11) NOT NULL,
    [Nome] [varchar](250) NOT NULL,
    [RG] [varchar](20),
    [DataExpedicao] [datetime] NOT NULL,
    [OrgaoExpedicao] [varchar](100),
    [UF] [varchar](2),
    [DataNascimento] [datetime] NOT NULL,
    [Sexo] [varchar](100) NOT NULL,
    [EstadoCivil] [varchar](100) NOT NULL,
    CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Endereco] (
    [Id] [uniqueidentifier] NOT NULL,
    [Cep] [varchar](8) NOT NULL,
    [Logradouro] [varchar](100) NOT NULL,
    [Numero] [varchar](10) NOT NULL,
    [Complemento] [varchar](100),
    [Bairro] [varchar](100) NOT NULL,
    [Cidade] [varchar](100) NOT NULL,
    [UF] [varchar](2) NOT NULL,
    CONSTRAINT [PK_dbo.Endereco] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Estado] (
    [Id] [uniqueidentifier] NOT NULL,
    [Sigla] [varchar](2) NOT NULL,
    [Descricao] [varchar](50) NOT NULL,
    CONSTRAINT [PK_dbo.Estado] PRIMARY KEY ([Id])
)

INSERT INTO [dbo].[Estado] (Id ,Descricao,Sigla) 
VALUES
(NEWID(), 'Acre', 'AC'),
(NEWID(), 'Alagoas', 'AL'),
(NEWID(), 'Amazonas', 'AM'),
(NEWID(), 'Amapá', 'AP'),
(NEWID(), 'Bahia', 'BA'),
(NEWID(), 'Ceará', 'CE'),
(NEWID(), 'Distrito Federal', 'DF'),
(NEWID(), 'Espírito Santo', 'ES'),
(NEWID(), 'Goiás', 'GO'),
(NEWID(), 'Maranhão', 'MA'),
(NEWID(), 'Minas Gerais', 'MG'),
(NEWID(), 'Mato Grosso do Sul', 'MS'),
(NEWID(), 'Mato Grosso', 'MT'),
(NEWID(), 'Pará', 'PA'),
(NEWID(), 'Paraíba', 'PB'),
(NEWID(), 'Pernambuco', 'PE'),
(NEWID(), 'Piauí', 'PI'),
(NEWID(), 'Paraná', 'PR'),
(NEWID(), 'Rio de Janeiro', 'RJ'),
(NEWID(), 'Rio Grande do Norte', 'RN'),
(NEWID(), 'Rondônia', 'RO'),
(NEWID(), 'Roraima', 'RR'),
(NEWID(), 'Rio Grande do Sul', 'RS'),
(NEWID(), 'Santa Catarina', 'SC'),
(NEWID(), 'Sergipe', 'SE'),
(NEWID(), 'São Paulo', 'SP'),
(NEWID(), 'Tocantins', 'TO')

CREATE INDEX [IX_Id] ON [dbo].[Endereco]([Id])
ALTER TABLE [dbo].[Endereco] ADD CONSTRAINT [FK_dbo.Endereco_dbo.Cliente_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Cliente] ([Id])
