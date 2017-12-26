CREATE VIEW VI_FUNCAO_FUNC AS
SELECT  
	ID_FUNCAO_FUNC,
	DAT_CRIADO,
	DAT_DESATIVADO,
	COD_FUNCAO,
	DSC_FUNCAO,
	FLG_ATIVO,
	CASE WHEN FLG_ATIVO = 'S' THEN 
	  'SIM'
	  ELSE
	  'N�O'
	  END AS DSC_ATIVO
FROM PUBLIC.TB_FUNCAO_FUNC	  
