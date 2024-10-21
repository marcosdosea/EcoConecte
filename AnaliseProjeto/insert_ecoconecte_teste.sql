INSERT INTO `ecoconecte`.`Pessoa` (`cpf`, `nome`, `telefone`, `logradouro`, `bairro`, `numero`, `cidade`, `estado`, `status`)
VALUES 
('12345678901', 'Carlos Silva', '1199999999', 'Rua das Flores', 'Centro', '100', 'São Paulo', 'SP', 'A'),
('98765432100', 'Maria Oliveira', '1198888888', 'Av. Brasil', 'Jardim', '50', 'São Paulo', 'SP', 'A'),
('32165498711', 'João Souza', '1197777777', 'Rua do Comércio', 'Industrial', '120', 'Campinas', 'SP', 'I');

INSERT INTO `ecoconecte`.`Cooperativa` (`nome`, `inscricaoEstadual`, `inscricaoMunicipal`, `cnpj`, `cep`, `logradouro`, `bairro`, `numero`, `telefone`, `email`, `idPessoaRepresentate`, `status`)
VALUES 
('Cooperativa Verde', '123456789', '987654321', '11222333444455', '01001000', 'Rua A', 'Centro', '123', '11999990000', 'cooperativa@verde.com', 1, 'A'),
('Recicla Tudo', '987654321', '123456789', '99887766554433', '02002000', 'Av. B', 'Bairro Novo', '321', '11988880000', 'recicla@tudo.com', 2, 'A');

INSERT INTO `ecoconecte`.`Agendamento` (`data`, `cep`, `logradouro`, `numero`, `idPessoa`, `bairro`, `cidade`, `estado`, `status`)
VALUES 
('2024-10-25 14:30:00', '12345000', 'Rua X', '15', 1, 'Centro', 'São Paulo', 'SP', 'A'),
('2024-11-01 10:00:00', '54321000', 'Rua Y', '50', 2, 'Jardim', 'São Paulo', 'SP', 'A');

INSERT INTO `ecoconecte`.`VendaMaterial` (`tipo`, `valor`, `quantidade`, `data`, `idCooperativa`, `idPessoa`)
VALUES 
('M', 500.00, 20.00, '2024-10-20 09:00:00', 1, 1),
('P', 200.00, 15.00, '2024-10-21 11:00:00', 2, 2);

INSERT INTO `ecoconecte`.`RotinaDeColeta` (`cep`, `logradouro`, `numero`, `diaColeta`, `horarioInicio`, `horarioTermino`, `idCooperativa`)
VALUES 
('01001000', 'Rua A', 123, '2024-10-25 06:00:00', '2024-10-25 06:30:00', '2024-10-25 07:30:00', 1),
('02002000', 'Av. B', 321, '2024-10-26 08:00:00', '2024-10-26 08:15:00', '2024-10-26 09:00:00', 2);

INSERT INTO `ecoconecte`.`Noticia` (`titulo`, `conteudo`, `idCooperativa`, `data`)
VALUES 
('Nova parceria com empresa de reciclagem', 'Estamos felizes em anunciar uma nova parceria...', 1, '2024-10-20 08:00:00'),
('Cooperativa ganha prêmio ambiental', 'A Recicla Tudo foi premiada por suas iniciativas...', 2, '2024-10-21 10:00:00');

INSERT INTO `ecoconecte`.`Orientacoes` (`titulo`, `descricao`, `idCooperativa`)
VALUES 
('Separação correta de materiais', 'Aprenda como separar materiais recicláveis...', 1),
('Dicas de coleta seletiva', 'Veja como organizar a coleta em sua casa...', 2);
