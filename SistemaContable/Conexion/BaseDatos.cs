using OracleBdd;
using SistemaContable.Models;
using System.Collections.Generic;
using System.Data;

namespace SistemaContable.Conexion
{
    public class BaseDatos
    {
        public BaseDatos() { }

        public List<Cuenta> ConsultaCuenta()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            var conexion = new ConexionBdd();

            // Abre la conexión antes de realizar la consulta
            if (conexion.Open("Admin", "Contabilidad2024", "contabilidad_high", "contabilidad"))
            {
                if (conexion.Query("SELECT * FROM CUENTASBANCARIAS"))
                {
                    DataSet data = conexion.ResultDataSet();
                    foreach (DataRow item in data.Tables[0].Rows)
                    {
                        cuentas.Add(new Cuenta()
                        {
                            CuentaId = int.Parse(item["CUENTAID"].ToString()),
                            Numcuenta = int.Parse(item["NUMCUENTA"].ToString()),
                            TipoCuenta = item["TIPOCUENTA"].ToString(),
                            Tipomoneda = item["TIPOMONEDA"].ToString(),
                            MontoApertura = decimal.Parse(item["MONTO"].ToString()),
                            Banco = int.Parse(item["BANCOID"].ToString())
                        });
                    }
                }
                // Cierra la conexión después de realizar la consulta
                conexion.Close();
            }

            return cuentas;
        }
    }
}


/*using OracleBdd;
using SistemaContable.Models;
using System.Data;

namespace SistemaContable.Conexion
{
    public class BaseDatos
    {
        public BaseDatos() { }

        public List<Cuenta> ConsultaCuenta()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            var conexion = new ConexionBdd();

            // Abre la conexión antes de realizar la consulta
            if (conexion.Open("Admin", "Contabilidad2024", "contabilidad_high", "contabilidad"))
            {
                if (conexion.Query("SELECT * FROM CUENTASBANCARIAS"))
                {
                    DataSet data = conexion.ResultDataSet();
                    foreach (DataRow item in data.Tables[0].Rows)
                    {
                        cuentas.Add(new Cuenta()
                        {
                            CuentaId = int.Parse(item["CUENTAID"].ToString()),
                            Numcuenta = int.Parse(item["NUMCUENTA"].ToString()),
                            TipoCuenta = item["TIPOCUENTA"].ToString(),
                            Tipomoneda = item["TIPOMONEDA"].ToString(),
                            MontoApertura = decimal.Parse(item["MONTO"].ToString()),
                            Banco = int.Parse(item["BANCOID"].ToString())
                        });
                    }

                }
                // Cierra la conexión después de realizar la consulta
                conexion.Close();
            }

            return cuentas;
        }
    }
}

*/