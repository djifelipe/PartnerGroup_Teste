using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PartnerGroupAPI.Models;

namespace PartnerGroupAPI.DAL
{
    public class MarcaDAL : IData<Marcas, Guid>
    {
        readonly string strConnect;
        
        public MarcaDAL()
        {
            strConnect = Startup.ConnectionString;
        }

        public void Delete(Guid key)
        {
            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "DELETE FROM MARCA WHERE MARCAID =@Id";
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

        public List<Marcas> GetAll()
        {
            List<Marcas> list = new List<Marcas>();

            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "SELECT * FROM MARCA A (NOLOCK) ORDER BY A.NOME";
                SqlCommand cmd = new SqlCommand(qry, cnx);

                Marcas marca = null;
                try
                {
                    cnx.Open();
                    using (var res = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (res.Read())
                        {
                            marca = new Marcas();
                            marca.MarcaID = Guid.Parse(res["MarcaID"].ToString());
                            marca.Nome = res["Nome"].ToString();                            

                            list.Add(marca);
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

        public Marcas GetByID(Guid key)
        {
            Marcas marca = null;

            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "SELECT * FROM MARCA A (NOLOCK) WHERE A.MARCAID = @Id";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@Id", key);

                try
                {
                    cnx.Open();
                    using (var res = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (res.Read())
                        {
                            marca = new Marcas();
                            marca.MarcaID = Guid.Parse(res["MarcaID"].ToString());
                            marca.Nome = res["Nome"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return marca;
        }

        public void Insert(Marcas entity)
        {
            using (var cnx = new SqlConnection(strConnect))
            {
                entity.MarcaID = Guid.NewGuid();
                string qry = "INSERT INTO MARCA VALUES(@MARCAID, @NOME)";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@MARCAID", entity.MarcaID);
                cmd.Parameters.AddWithValue("@NOME", entity.Nome);                

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

        public void Update(Marcas entity)
        {
            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "UPDATE MARCA SET NOME = @NOME WHERE MARCAID=@MARCARID";
                SqlCommand cmd = new SqlCommand(qry, cnx);                                                
                cmd.Parameters.AddWithValue("@NOME", entity.Nome);
                cmd.Parameters.AddWithValue("@MARCAID", entity.MarcaID);

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

        public List<Patrimonios> GetPatrimonioByMarca(Guid marcaID)
        {
            List<Patrimonios> list = new List<Patrimonios>();
            Patrimonios p = null;

            using (var cnx = new SqlConnection(strConnect))
            {
                string qry = "SELECT * FROM PATRIMONIO A (NOLOCK) WHERE A.MARCAID = @MARCAID";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@MARCAID", marcaID);

                try
                {
                    cnx.Open();

                    using (var res = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (res.Read())
                        {
                            p = new Patrimonios();
                            p.PatrimonioID = Guid.Parse(res["PatrimonioID"].ToString());
                            p.Nome = res["Nome"].ToString();
                            p.MarcaID = Guid.Parse(res["MarcaID"].ToString());
                            p.Descricao = res["Descricao"].ToString();
                            p.NTombo = (int)res["NTombo"];

                            list.Add(p);
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

        public bool ExistsMarca(string nome)
        {
            bool result = false;
            using (var cnx = new SqlConnection(strConnect))
            { 
                string qry = "SELECT TOP 1 A.NOME FROM MARCA A (NOLOCK) WHERE A.NOME = @NOME";
                SqlCommand cmd = new SqlCommand(qry, cnx);
                cmd.Parameters.AddWithValue("@NOME", nome);

                try
                {
                    cnx.Open();
                    using (var res = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        if (res.HasRows)
                            result = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

    }
}
