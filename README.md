# PartnerGroup_Teste
 Projeto de teste da PartnerGroup

////********* PartnerGroupAPI *********////

Este projeto foi densenvolvido utilizando um modelo bem próximo do MVC, embora não possua as views, por questão de organização, foi criado uma pasta para os objetos de acesso ao banco de dados DAL
Para os testar os endpoints utilizei o "Postman" <br>

O projeto foi desenvolvido a partir do banco de dados, onde criei as tabelas e os campos de acordo com a especificação. <br>
	Obs.: Para recriar o banco de dados utilizar os arquivos que estão na past "Scripts", executar na ordem a seguir: <br>
			1 - CreateDatabase <br>
			2 - Table_Marca <br>
			3 - Table_Patrimonio <br>
			4 - Trigger_AddTombo <br><br>

Em seguida criei as classes que representam essas tabelas.<br>
Para a camada de acesso a dados, criei uma interface com todas as operações de CRUD, e implementando nas classes de <br>
acesso de cada tabela <br>
Em seguida foi criado as classes de controle, com os endpoints: <br>
PatrimonioController -> PatrimonioList() é o Get principal que lista todos os patrimonios. <br>
						url = "http://localhost:51031/api/patrimonio/" <br><br>
PatrimonioController -> GetPatrimonioByID(Guid) Busca o registro usando como parametro o campo PatrimonioID <br>
						url = http://localhost:51031/api/patrimonio/a3b58095-4557-40fd-950e-8e7ca9f3da8a<br><br>
PatrimonioController -> Insert(Patrimonio) Valida e insere um novo registro, o parametro é um instancia da classe "Patrimonios"<br>
						o campo "nTombo" vai zerado pois no tabela tem um trigger que gera o valor para este campo<br>
						url = http://localhost:51031/api/patrimonio/ <br>
						json do objeto <br>
						{<br>
							"patrimonioID": "00000000-0000-0000-0000-000000000000",<br>
							"nome": "Patrimonio ALTERADO",<br>
							"marcaID": "232217d4-4452-4723-a7e5-c938357fd18f",<br>
							"descricao": "teste ALTERAÇÃO",<br>
							"nTombo": 0 <br>
						}<br><br>
PatrimonioController -> Edit(Patrimonio) Valida e atualiza um registro já existente, o parametro é um instancia da classe "Patrimonios"<br>
						url = http://localhost:51031/api/patrimonio/<br>
						json do objeto<br>
						{<br>
							"patrimonioID": "92fc825c-539d-4490-970a-be8bac680052",<br>
							"nome": "Patrimonio ALTERADO",<br>
							"marcaID": "232217d4-4452-4723-a7e5-c938357fd18f",<br>
							"descricao": "teste ALTERAÇÃO"<br>
						}<br><br>
PatrimonioController -> Delete(Guid) Deleta um registro usando como parametro o campo PatrimonioID <br>
						url = http://localhost:51031/api/patrimonio/a3b58095-4557-40fd-950e-8e7ca9f3da8a<br><br>


MarcaController ->	MarcaList() é o Get principal que lista todas as marcas<br>
					url	= http://localhost:51031/api/marca/<br><br>

MarcaController ->	GetMarcaByID(Guid) Busca o registro usando como parametro o campo MarcaID<br>
					url = http://localhost:51031/api/marca/GetmarcaByID/c51553d4-58fa-4514-8716-3b0537409d7c<br><br>

MarcaController ->	Insert(Marca) Valida e insere um novo registro, o parametro é um instancia da classe Marcas<br>
					url = http://localhost:51031/api/marca/<br>
					json do objeto<br>
					{<br>
						"marcaID": "00000000-0000-0000-0000-000000000000",<br>
						"nome": "Marca Alterada"<br>
					}<br><br>

MarcaController ->  Edit(Marcas) Valida e atualiza um registro já existente, o parametro é um instancia da classe Marcas<br>
					url = http://localhost:51031/api/marca/<br>
					json do objeto<br>
					{<br>
						"marcaID": "c51553d4-58fa-4514-8716-3b0537409d7c",<br>
						"nome": "Marca Alterada"<br>
					}<br><br>

MarcaController ->	Delete(Guid) Deleta um registro usando como parametro o campo MarcaID<br>
					url = http://localhost:51031/api/marca/GetPatrimoniosByMarca/43ab797d-70de-47cb-a17c-41c862ea9e00<br><br>

MarcaController ->  GetPatrimonioByMarca(Guid) Lista todos os Patrimonios relacionados com a Marca utilizando <br>como parametro o campo MarcaID<br>
					url = http://localhost:51031/api/marca/GetPatrimoniosByMarca/43ab797d-70de-47cb-a17c-41c862ea9e00<br><br>
