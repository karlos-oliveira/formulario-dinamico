CREATE VIEW vw_atributos
as

SELECT 
		MO.IDMODELO 'IdModelo',
		MO.NOME 'Modelo',
		MOAT.VERSAO 'Versao',
		MOAT.ORDEM 'Ordem',
		MOAT.OBRIGATORIO 'Obrigatorio',
		MOAT.MULTIPLAESCOLHA 'MultiplaEscolha',
		MOAT.OPCOES 'Opcoes',
		ATR.IDATRIBUTO 'IdAtributo',
		ATR.NOMECAMPO 'NomeCampo',
		ATR.LABEL 'Label',
		ATR.DESCRICAO 'Descricao',
		ATR.TAMANHOMaximo 'TamanhoMaximo',
		TPA.IDTIPOATRIBUTO 'IdTipo',
		TPA.NOME 'Tipo',
		ATR.IsAtivo 'IsAtivo'
FROM 
	"ATRIBUTO" ATR

INNER JOIN "TIPOATRIBUTO" TPA
ON ATR.IDTIPOATRIBUTO = TPA.IDTIPOATRIBUTO

/*
select * from "Modelo"
select * from modeloatributo
select * from atributo
select * from tipoatributo
*/


