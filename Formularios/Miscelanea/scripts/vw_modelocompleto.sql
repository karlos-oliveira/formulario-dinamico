CREATE VIEW vw_modelocompleto
as

SELECT 
		"Modelo"."IdModelo"  'IdModelo',
		"Modelo"."Nome" 'Modelo',
		"ModeloAtributo"."Versao" 'Versao',
		"ModeloAtributo"."Ordem" 'Ordem',
		"ModeloAtributo"."Obrigatorio" 'Obrigatorio',
		"ModeloAtributo"."MultiplaEscolha" 'MultiplaEscolha',
		"ModeloAtributo"."Opcoes" 'Opcoes',
		"Atributo"."IdAtributo" 'IdAtributo',
		"Atributo"."NomeCampo" 'NomeCampo',
		"Atributo"."Label" 'Label',
		"Atributo"."Descricao" 'Descricao',
		"Atributo"."TamanhoMaximo" 'TamanhoMaximo',
		"TipoAtributo"."IdTipoAtributo" 'IdTipo',
		"TipoAtributo"."Nome" 'Tipo'
FROM 
	"Modelo"

INNER JOIN "ModeloAtributo"
ON "ModeloAtributo"."IdModelo" = "Modelo"."IdModelo"

INNER JOIN "Atributo"
ON "Atributo"."IdAtributo"  = "ModeloAtributo"."IdAtributo"

INNER JOIN "TipoAtributo"
ON "Atributo"."IdTipoAtributo" = "TipoAtributo"."IdTipoAtributo" 

