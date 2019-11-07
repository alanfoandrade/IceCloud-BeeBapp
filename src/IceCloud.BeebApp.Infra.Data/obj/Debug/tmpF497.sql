CREATE TABLE [dbo].[Clientes] (
    [Id] [uniqueidentifier] NOT NULL,
    [Nome] [varchar](150) NOT NULL,
    [Email] [varchar](100) NOT NULL,
    [CPF] [varchar](11) NOT NULL,
    [DataNascimento] [datetime] NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    [Ativo] [bit] NOT NULL,
    [Excluido] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Clientes] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Enderecos] (
    [Id] [uniqueidentifier] NOT NULL,
    [Logradouro] [varchar](150) NOT NULL,
    [Numero] [varchar](20) NOT NULL,
    [Complemento] [varchar](100),
    [Bairro] [varchar](50) NOT NULL,
    [CEP] [varchar](8) NOT NULL,
    [Cidade] [varchar](100),
    [Estado] [varchar](100),
    [ClienteId] [uniqueidentifier] NOT NULL,
    CONSTRAINT [PK_dbo.Enderecos] PRIMARY KEY ([Id])
)
CREATE UNIQUE INDEX [IX_CPF] ON [dbo].[Clientes]([CPF])
CREATE INDEX [IX_ClienteId] ON [dbo].[Enderecos]([ClienteId])
ALTER TABLE [dbo].[Enderecos] ADD CONSTRAINT [FK_dbo.Enderecos_dbo.Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Clientes] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201909130150269_AutomaticMigration', N'IceCloud.BeebApp.Infra.Data.Migrations.Configuration',  0x1F8B0800000000000400E55ADB6EE336107D2FD07F10F45864AD248B02A961EF22719285D18D13C4C9A26F012D8D1DA214A915A9C046D12FEB433FA9BFD0D18D9228CB967C597451ECCB8622CF0C8733879C93FCF3D7DF838F4B9F596F104A2AF8D03EEB9DDA16705778942F8676A4E6EF2EEC8F1F7EFC6170E3F94BEB4B3EEF7D3C0F577239B45F950AFA8E23DD57F089ECF9D40D851473D57385EF104F38E7A7A7BF3867670E20848D589635788CB8A23E243FE08F23C15D085444D89DF080C96C1CBF4C13546B427C90017161688F5D18311179BD2B80D96510F4C67C1E92DE3551A487380A96CAB62E1925E8DA14D8DCB608E74211858EF79F254C5528F8621AE000614FAB0070DE9C3009D986FAC5F4B67B3B3D8FF7E6140B732837924AF81D01CFDE67C172CCE53B85DCD6C1C470DE60D8D52ADE7512D2A13D62143066B665DAEA8F5818CF5B13F06B9C47792F3DAA5E86706235CC3BD15983C915FF3BB14611535108430E910A093BB11EA219A3EEAFB07A12BF031FF288B1B2DBE8387EAB0CE0D043280208D5EA11E6D966C69E6D39D5758EB9502F2BAD49F7F929A2F8FF09DA2633063A299C8DCB27C2871C00330BABC6B6EEC8F233F0857AC57AFA19EBE4962EC1CB4732D4674EB1C870910A23E86CF50603CB36993D3D8AD9D1C3ED26A36786CDD4C67E26E3B29E10E92259702572EB380A4FD4DF0D6E443C229104F606BB54F44DA35C09C180F0EE47B97419265E779C0979A38BA4544D44EE4108AE90B6F5082C99215F6990B2612FFFFAA22BFF3614FEA360A595F9B79727122E00E9F449344C988A28740DDF064EC1321BB92747DB837C7288FF29FB7C168B10E93E2A92F9DB71D024F261A3DDF3E37090F003061536D8830037DBBA2234DCB8C5E3447674F3B0C1E6C5115876443DE26DBCC70E12CF1BA98877FC63CBC8A96B6D3512AA66CA7DE93467CB463ACDF9B60D9D5E4A295C9AF863F0A9F6A5BA3FFC6C6D732C3D98F2C6F07C902F69800C894E0CED9F6A71DB80ABEF8F0257C7A90A7B5683456245301EBFD2F1598F1736B2B9AAB330E52E0D08DBE281B1AE257FC7C1D716CC2FD710005AE36A4B50DB982E656CDD036DC8B85BB60568E09452A47E11C7BD12AE803027BBF4DED42D54ED4EC6DE29BB96655687661EC4B05350D54DE133A4486033096AA95485283D656A1845821A20A55DD7918A3A2D4D6BAA65F3285A5490DE41C5F9DAA1B6A89912521149F37D51DDEB1AD6D0A75CB4D44EDA53E7BDB7D3D07C0FEE48102041979AF16CC49AA69DF8E8DDB47B47EAA7188E2BD734A6DA5B6D4989902CC0F81ABF023CB8A5A154F1837E4662361F797E6D9A91D30DC9961B33D2B67E667906E60BE2FF67DCB15D94E835645511D75BDC6AFCB049760DF5F3AFAF4C0412C248B8E65939122CF27933B535AF4E7BDAF2FA74A43D42D69F9621B2A1F61849B359464806DAAF373BC73294F9AD1B6AD1409A98C597F68859175986CA863AC45B37919590EBD13AD2C03192AE76EDD4D2DDA01EB37C5A1557C18987AE2E7D1D742FAFE6A5C7A9AF72D75646298F77A8D6AC0FABD46B36D6A1DACA6D55A5EACA1FDAE3E5AD53192A1FEBE055DC0955BC89073AACCFFA9A0A4436D6A1BAB2B6A5525BD958075F8A375EC59DE6A7DF91ABB4F64430A768EBFAA9603C0906D9F5BC5DB4AFDDD7E914DBC220BD512FBEABA72BA9C04F8B7AFA95A5712926DC114EE72055AAD1D8F89CB83064FEFF8EE4EE48E9B15D75F731B2D17268FF61FDF9ED45A888D3AF11D0B8D9A0730AE15E72F81B09DD5712D6B5A87DC4EEB5A0A7DD414B52B6866C3E8A784DDF1AFFF682CB4EACB17C4EE2D4B79EB00BC2733255F08368DC1E51A00EA571EF0C56D1B86754EDAD6F6FC738847EFC5D17515DD53D54295535DB75A8E73B94525D916D51A5DDF5D775A03BC4A0A4AEAE43BCD8533C3DD0D6AB52E981406BC2683D55DB70608E7262DD8758817DEB34E6C09D6A7A0F1153DFA0BB888B75FD6547F1732795B25909389A2AF9DDC8907565A795CAB849644CDF9A7809CEE2534E73B451526B9220372A90EB2C34CA7FDF44A034C2529191DAC8916B95CCE3E88FF5260293AAF4F74198D3922E0A88F8AF8538B89574D273C67C2EF2C4363CCAA718A47807C8B4986B9721722071157E7641CAE457535F088B9217E80CBC31BF8F541029DC32F833B62A0723AE8E4DF61391B5EAF3E03E487E9574882DA09B347EE1DDF3AB88324FFB7DBB86881B20E2B2FB04389E9E2556B182C54A234D046F0994854FB3C513E0EB00C1E43D9F9237D8C5B767099F6141DC55DE0B36836C3F886AD807D794E063CB971946B11E7FC41CF6FCE5877F01F92F5EB226270000 , N'6.2.0-61023')

