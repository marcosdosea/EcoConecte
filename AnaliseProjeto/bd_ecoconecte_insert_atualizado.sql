INSERT INTO `ecoconecte`.`Pessoa` (`cpf`, `nome`, `telefone`, `logradouro`, `bairro`, `numero`, `cidade`, `estado`, `status`)
VALUES 
('12345678901', 'Carlos Silva', '1199999999', 'Rua das Flores', 'Centro', '100', 'São Paulo', 'SP', 'A'),
('98765432100', 'Maria Oliveira', '1198888888', 'Av. Brasil', 'Jardim', '50', 'São Paulo', 'SP', 'A'),
('32165498711', 'João Souza', '1197777777', 'Rua do Comércio', 'Industrial', '120', 'Campinas', 'SP', 'I'),
('11122233344', 'Carlos Silva', '1198765432', 'Rua X', 'Centro', '10', 'São Paulo', 'SP', 'A'),
('22233344455', 'Ana Souza', '1191234567', 'Rua Y', 'Bairro B', '20', 'São Paulo', 'SP', 'A'),
('33344455566', 'João Lima', '1192345678', 'Rua Z', 'Bairro C', '30', 'São Paulo', 'SP', 'I'),
('44455566677', 'Mariana Costa', '1193456789', 'Rua W', 'Bairro D', '40', 'São Paulo', 'SP', 'A'),
('55566677788', 'Lucas Oliveira', '1194567890', 'Rua V', 'Bairro E', '50', 'São Paulo', 'SP', 'A');

INSERT INTO `ecoconecte`.`Cooperativa` (`nome`, `inscricaoEstadual`, `inscricaoMunicipal`, `cnpj`, `cep`, `logradouro`, `bairro`, `numero`, `telefone`, `email`, `idPessoaRepresentate`, `status`)
VALUES 
('Cooperativa Verde', '123456789', '987654322', '11222333444455', '01001000', 'Rua A', 'Centro', '123', '1199999000', 'cooperativa@verde.com', 1, 'A'),
('Recicla Tudo', '987654321', '123456799', '99887766554433', '02002000', 'Av. B', 'Bairro Novo', '321', '1198888000', 'recicla@tudo.com', 1, 'A'),
('Cooperativa Verde', '123456788', '987654321', '11.222.333/0001-44', '01001-000', 'Rua A', 'Centro', '100', '1198765432', 'contato@verde.com', 1, 'A'),
('EcoColeta', '223344556', '556677889', '22.333.444/0001-55', '02002-000', 'Rua B', 'Bairro B', '200', '1191234567', 'contato@ecocoleta.com', 1, 'A'),
('ReciclaMais', '334455667', '667788990', '33.444.555/0001-66', '03003-000', 'Rua C', 'Bairro C', '300', '1192345678', 'contato@reciclamais.com', 1, 'I'),
('ReusoConsciente', '445566778', '778899001', '44.555.666/0001-77', '04004-000', 'Rua D', 'Bairro D', '400', '1193456789', 'contato@reuso.com', 1, 'A'),
('SustentaVida', '556677889', '889900112', '55.666.777/0001-88', '05005-000', 'Rua E', 'Bairro E', '500', '1194567890', 'contato@sustenta.com', 1, 'A');

INSERT INTO `ecoconecte`.`Agendamento` (`data`, `cep`, `logradouro`, `numero`, `idPessoa`, `bairro`, `cidade`, `estado`, `status`)
VALUES 
('2024-10-25 14:30:00', '12345000', 'Rua X', '15', 1, 'Centro', 'São Paulo', 'SP', 'A'),
('2024-11-01 10:00:00', '54321000', 'Rua Y', '50', 2, 'Jardim', 'São Paulo', 'SP', 'A'),
('2025-03-10 10:00:00', '01001-000', 'Rua A', '100', 1, 'Centro', 'São Paulo', 'SP', 'A'),
('2025-03-11 11:00:00', '02002-000', 'Rua B', '200', 2, 'Bairro B', 'São Paulo', 'SP', 'A'),
('2025-03-12 12:00:00', '03003-000', 'Rua C', '300', 3, 'Bairro C', 'São Paulo', 'SP', 'C'),
('2025-03-13 13:00:00', '04004-000', 'Rua D', '400', 4, 'Bairro D', 'São Paulo', 'SP', 'A'),
('2025-03-14 14:00:00', '05005-000', 'Rua E', '500', 5, 'Bairro E', 'São Paulo', 'SP', 'A');

INSERT INTO `ecoconecte`.`VendaMaterial` (`tipo`, `valor`, `quantidade`, `data`, `idCooperativa`, `idPessoa`)
VALUES 
('M', 500, 20, '2024-10-20', 1, 1),
('P', 200, 15, '2024-10-21', 2, 2),
('M', 150, 20, '2025-02-15', 1, 1),
('P', 200, 15, '2025-02-16', 2, 2),
('M', 300, 25, '2025-02-17', 1, 1),
('P', 120, 10, '2025-02-18', 2, 2),
('M', 500, 30, '2025-02-19', 1, 1);

INSERT INTO `ecoconecte`.`RotinaDeColeta` (`cep`, `logradouro`, `numero`, `diaColeta`, `horarioInicio`, `horarioTermino`, `idCooperativa`)
VALUES 
('49517001', 'Rua B', '45', '2025-02-10 00:00:00', '2025-02-10 09:00:00', '2025-02-10 09:30:00', '1'),
('49517002', 'Rua C', '78', '2025-02-10 00:00:00', '2025-02-10 10:00:00', '2025-02-10 10:45:00', '2'),
('49517003', 'Rua D', '12', '2025-02-10 00:00:00', '2025-02-10 11:00:00', '2025-02-10 11:30:00', '1'),
('49517004', 'Rua E', '59', '2025-02-10 00:00:00', '2025-02-10 14:00:00', '2025-02-10 14:30:00', '3'),
('49517005', 'Rua F', '20', '2025-02-10 00:00:00', '2025-02-10 15:00:00', '2025-02-10 15:30:00', '2');

INSERT INTO `ecoconecte`.`Noticia` (`titulo`, `conteudo`, `idCooperativa`, `data`)
VALUES 
('Nova parceria com empresa de reciclagem', 'Estamos felizes em anunciar uma nova parceria...', 1, '2024-10-20'),
('Cooperativa ganha prêmio ambiental', 'A Recicla Tudo foi premiada por suas iniciativas...', 2, '2024-10-21'),
('Reciclagem cresce', 'A reciclagem tem aumentado significativamente...', 1, '2025-02-25'),
('Nova legislação', 'O governo aprovou novas leis ambientais...', 2, '2025-02-26'),
('Feira de sustentabilidade', 'Evento anual sobre sustentabilidade...', 3, '2025-02-27'),
('Projeto Verde', 'Lançado um novo projeto de reciclagem...', 4, '2025-02-28'),
('Conscientização ambiental', 'Campanha para incentivar a reciclagem...', 5, '2025-03-01');

INSERT INTO `ecoconecte`.`Orientacoes` (`titulo`, `descricao`, `idCooperativa`)
VALUES 
('Separação correta de materiais', 'Aprenda como separar materiais recicláveis...', 1),
('Dicas de coleta seletiva', 'Veja como organizar a coleta em sua casa...', 2),
('Como separar lixo reciclável', 'Dicas para separar corretamente...', 1),
('Reaproveitamento de materiais', 'Ideias para reutilizar objetos...', 2),
('Impacto da reciclagem', 'Benefícios ambientais da reciclagem...', 3),
('Coleta seletiva', 'Explicação sobre o funcionamento...', 4),
('Reduzindo o desperdício', 'Como evitar o desperdício de materiais...', 5);
