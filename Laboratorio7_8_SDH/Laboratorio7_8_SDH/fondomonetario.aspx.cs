using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;

namespace Laboratorio7_8_SDH
{
    public partial class fondomonetario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargaGrid();
            }

        }

        public void cargaGrid()
        {
            using(ModeloMONETARIO contextoBD = new ModeloMONETARIO())
            {
                GrdMonetario.DataSource = contextoBD.GESTIONPRESTAMO.ToList();
                GrdMonetario.DataBind();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            using(ModeloMONETARIO contextoBD = new ModeloMONETARIO())
            {
                PAIS objPais = new PAIS();
                objPais.ID_PAIS = (ddlPais.SelectedIndex) + 1;
                objPais.DESCRIPCION = ddlPais.Text;
                contextoBD.PAIS.Add(objPais);
                                

                IDIOMA objIdioma = new IDIOMA();
                objIdioma.ID_IDIOMA = (ddlIdioma.SelectedIndex) + 1;
                objIdioma.DESC_IDIOMA = ddlIdioma.Text;
                contextoBD.IDIOMA.Add(objIdioma);
                

                GESTIONPRESTAMO objPrestamo = new GESTIONPRESTAMO();
                objPrestamo.ID_PAIS = (ddlPais.SelectedIndex) + 1;
                objPrestamo.CANT_HABIT = Convert.ToInt32(txtHabitantes.Text);
                objPrestamo.ID_IDIOMA = (ddlIdioma.SelectedIndex) + 1;
                objPrestamo.PIB = Convert.ToDouble(txtPIB.Text);
                objPrestamo.SUPERFICIE = Convert.ToDouble(txtSuperficie.Text);
                if (rbnRiesgo.SelectedIndex == 0)
                {
                    objPrestamo.RIESGO = "Alto";
                }
                else if (rbnRiesgo.SelectedIndex == 1)
                {
                    objPrestamo.RIESGO = "Medio";
                }
                else
                {
                    objPrestamo.RIESGO = "Bajo";
                }
                if (cbxCredito.Checked == true)
                {
                    objPrestamo.PRESTAMO = 1;
                }
                else
                {
                    objPrestamo.PRESTAMO = 0;
                }
                contextoBD.GESTIONPRESTAMO.Add(objPrestamo);
                contextoBD.SaveChanges();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('Registro Creado')",true);
                cargaGrid();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using(ModeloMONETARIO contextoBD = new ModeloMONETARIO())
            {
                GESTIONPRESTAMO aux = contextoBD.GESTIONPRESTAMO.Where(x => x.ID_PAIS == (ddlPais.SelectedIndex) + 1).FirstOrDefault();
                if (aux == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('El registro no se encontro')", true);
                    return;
                }
                else
                {
                    aux.CANT_HABIT = Convert.ToInt32(txtHabitantes.Text);
                    aux.ID_IDIOMA = (ddlIdioma.SelectedIndex) + 1;
                    aux.PIB = Convert.ToDouble(txtPIB.Text);
                    aux.SUPERFICIE = Convert.ToDouble(txtSuperficie.Text);
                    if (rbnRiesgo.SelectedIndex == 0)
                    {
                        aux.RIESGO = "Alto";
                    }
                    else if (rbnRiesgo.SelectedIndex == 1)
                    {
                        aux.RIESGO = "Medio";
                    }
                    else
                    {
                        aux.RIESGO = "Bajo";
                    }
                    if (cbxCredito.Checked == true)
                    {
                        aux.PRESTAMO = 1;
                    }
                    else
                    {
                        aux.PRESTAMO = 0;
                    }
                }
                contextoBD.SaveChanges();
                cargaGrid();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (ModeloMONETARIO contextoBD = new ModeloMONETARIO())
            {

                GESTIONPRESTAMO aux = contextoBD.GESTIONPRESTAMO.Where(x => x.ID_PAIS == (ddlPais.SelectedIndex) + 1).FirstOrDefault();
                
                if (aux == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "s1", "alert('El registro no se encontro')", true);
                    return;
                }

                contextoBD.GESTIONPRESTAMO.Remove(aux);
                contextoBD.SaveChanges();
                cargaGrid();

            }

        }

       
    }
}