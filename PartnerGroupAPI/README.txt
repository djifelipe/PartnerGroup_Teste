////********* PartnerGroupAPI *********////

Este projeto foi densenvolvido utilizando um modelo bem próximo do MVC, embora não possua as views, por questão de organização, foi criado uma pasta para
os objetos de acesso ao banco de dados DAL
Para os testar os endpoints utilizei o "Postman"



O projeto foi desenvolvido a partir do banco de dados, onde criei as tabelas e os campos de acordo com a especificação.
	Obs.: Para recriar o banco de dados utilizar os arquivos que estão na past "Scripts", executar na ordem a seguir:
			1 - CreateDatabase
			2 - Table_Marca
			3 - Table_Patrimonio
			4 - Trigger_AddTombo

Em seguida criei as classes que representam essas tabelas.
Para a camada de acesso a dados, criei uma interface com todas as operações de CRUD, e implementando nas classes de acesso de cada tabela
Em seguida foi criado as classes de controle, com os endpoints:
PatrimonioController -> PatrimonioList() é o Get principal que lista todos os patrimonios. 
						url = "http://localhost:51031/api/patrimonio/"
PatrimonioController -> GetPatrimonioByID(Guid) Busca o registro usando como parametro o campo PatrimonioID
						url = http://localhost:51031/api/patrimonio/a3b58095-4557-40fd-950e-8e7ca9f3da8a
PatrimonioController -> Insert(Patrimonio) Valida e insere um novo registro, o parametro é um instancia da classe "Patrimonios"
						o campo "nTombo" vai zerado pois no tabela tem um trigger que gera o valor para este campo
						url = http://localhost:51031/api/patrimonio/ 
						json do objeto 
						{
							"patrimonioID": "00000000-0000-0000-0000-000000000000",
							"nome": "Patrimonio ALTERADO",
							"marcaID": "232217d4-4452-4723-a7e5-c938357fd18f",
							"descricao": "teste ALTERAÇÃO",
							"nTombo": 0    
						}
PatrimonioController -> Edit(Patrimonio) Valida e atualiza um registro já existente, o parametro é um instancia da classe "Patrimonios"
						url = http://localhost:51031/api/patrimonio/
						json do objeto
						{
							"patrimonioID": "92fc825c-539d-4490-970a-be8bac680052",
							"nome": "Patrimonio ALTERADO",
							"marcaID": "232217d4-4452-4723-a7e5-c938357fd18f",
							"descricao": "teste ALTERAÇÃO"
						}
PatrimonioController -> Delete(Guid) Deleta um registro usando como parametro o campo PatrimonioID
						url = http://localhost:51031/api/patrimonio/a3b58095-4557-40fd-950e-8e7ca9f3da8a


MarcaController ->	MarcaList() é o Get principal que lista todas as marcas
					url	= http://localhost:51031/api/marca/

MarcaController ->	GetMarcaByID(Guid) Busca o registro usando como parametro o campo MarcaID
					url = http://localhost:51031/api/marca/GetmarcaByID/c51553d4-58fa-4514-8716-3b0537409d7c

MarcaController ->	Insert(Marca) Valida e insere um novo registro, o parametro é um instancia da classe Marcas
					url = http://localhost:51031/api/marca/
					json do objeto
					{
						"marcaID": "00000000-0000-0000-0000-000000000000",
						"nome": "Marca Alterada"
					}

MarcaController ->  Edit(Marcas) Valida e atualiza um registro já existente, o parametro é um instancia da classe Marcas
					url = http://localhost:51031/api/marca/
					json do objeto
					{
						"marcaID": "c51553d4-58fa-4514-8716-3b0537409d7c",
						"nome": "Marca Alterada"
					}

MarcaController ->	Delete(Guid) Deleta um registro usando como parametro o campo MarcaID
					url = http://localhost:51031/api/marca/GetPatrimoniosByMarca/43ab797d-70de-47cb-a17c-41c862ea9e00

MarcaController ->  GetPatrimonioByMarca(Guid) Lista todos os Patrimonios relacionados com a Marca utilizando como parametro o campo MarcaID
					url = http://localhost:51031/api/marca/GetPatrimoniosByMarca/43ab797d-70de-47cb-a17c-41c862ea9e00