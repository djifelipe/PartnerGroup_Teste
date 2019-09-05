using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PartnerGroupAPI.Models;

namespace PartnerGroupAPI.DAL
{
    public class PatrimonioDAL : IData<Patrimonios, Guid>
    {

        readonly string strConnect;

        public PatrimonioDAL()
        {
            strConnect = Startup.ConnectionString;
        }

        public void Delete(Guid key)
        {
            using ( var cnx = new SqlConnection(strConnect))
            {
                string qry = "DELETE FROM PATRIMONIO WHERE PATRIMONIOID =@Id";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@Id", key);

                try
                {
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }                
        }

        public List<Patrimonios> GetAll()
        {
            List<Patrimonios> list = new List<Patrimonios>();

            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "SELECT A.PATRIMONIOID, A.MARCAID, A.NOME, A.DESCRICAO, A.NTOMBO FROM PATRIMONIO A (NOLOCK) ORDER BY A.NOME";
                SqlCommand cmd = new SqlCommand(qry, cnx);

                Patrimonios patrimonio = null;
                try
                {
                    cnx.Open();
                    using (var res = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (res.Read())
                        {
                            patrimonio = new Patrimonios();
                            patrimonio.PatrimonioID = Guid.Parse(res["PatrimonioID"].ToString());
                            patrimonio.Nome = res["Nome"].ToString();
                            patrimonio.MarcaID = Guid.Parse(res["MarcaID"].ToString());
                            patrimonio.Descricao = res["Descricao"].ToString();
                            patrimonio.NTombo = (int)res["NTombo"];

                            list.Add(patrimonio);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }                
            }

            return list;
        }

        public Patrimonios GetByID(Guid key)
        {
            Patrimonios patrimonio = null;

            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "SELECT A.PATRIMONIOID, A.MARCAID, A.NOME, A.DESCRICAO, A.NTOMBO FROM PATRIMONIO A (NOLOCK) WHERE A.PATRIMONIOID = @Id";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@Id", key);

                try
                {
                    cnx.Open();
                    using (var res = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (res.Read())
                        {                            
                             patrimonio = new Patrimonios();
                             patrimonio.PatrimonioID = Guid.Parse(res["PatrimonioID"].ToString());
                             patrimonio.Nome = res["Nome"].ToString();
                             patrimonio.MarcaID = Guid.Parse(res["MarcaID"].ToString());
                             patrimonio.Descricao = res["Descricao"].ToString();
                             patrimonio.NTombo = (int)res["NTombo"];
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            
            return patrimonio;
        }

        public void Insert(Patrimonios entity)
        {
            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "INSERT INTO PATRIMONIO (PATRIMONIOID, NOME, MARCAID, DESCRICAO) VALUES(@PARTRIMONIOID, @NOME, @MARCAID, @DESCRICAO)";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@PARTRIMONIOID", entity.PatrimonioID);
                cmd.Parameters.AddWithValue("@NOME", entity.Nome);
                cmd.Parameters.AddWithValue("@MARCAID", entity.MarcaID);
                cmd.Parameters.AddWithValue("@DESCRICAO", entity.Descricao);                

                try
                {
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(Patrimonios entity)
        {
            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "UPDATE PATRIMONIO SET NOME = @NOME, MARCAID = @MARCAID, DESCRICAO = @DESCRICAO WHERE PATRIMONIOID = @PARTRIMONIOID";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@PARTRIMONIOID", entity.PatrimonioID);
                cmd.Parameters.AddWithValue("@NOME", entity.Nome);
                cmd.Parameters.AddWithValue("@MARCAID", entity.MarcaID);
                cmd.Parameters.AddWithValue("@DESCRICAO", entity.Descricao);                

                try
                {
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
