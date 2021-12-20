using CSIS265FINAL.DataAccessLayer;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSIS265FINAL
{
    public partial class Cars : System.Web.UI.Page
    {
        protected CarDao carDao;
        private Car car;
        private log4net.ILog logger = LogManager.GetLogger("MyLogger");

        protected void Page_Load(object sender, EventArgs e)
        {
            InstantiateDao();
            if (Page.IsPostBack)
            {

            }
            else
            {

            }

            DisplayCars();
        }
        protected void DisplayCars()
        {
            try
            {
                rptData.DataSource = carDao.SelectManyObject(new Car());
                rptData.DataBind();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        protected void InstantiateDao()
        {
            try
            {
                carDao = new CarDao();
                car = new Car();
            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        protected void WipeOutControl()
        {

            txtMake.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtMpg.Text = string.Empty;

            hdnId.Value = string.Empty;

        }

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnId.Value.Trim().Length > 0)
                {
                    int id = Convert.ToInt32(hdnId.Value);
                    string make = txtMake.Text;
                    string model = txtModel.Text;
                    string color = txtColor.Text;
                    double weight = Convert.ToDouble(txtWeight.Text);
                    int mpg = Convert.ToInt32(txtMpg.Text);
                    car = new Car(id, make, model, color, weight, mpg);
                    carDao.Update(car);
                    txtAddSucsses.Text = "Car updated successfuly";
                    
                }
                else
                {
                 
                    string make = txtMake.Text;
                    string model = txtModel.Text;
                    string color = txtColor.Text;
                    double weight = Convert.ToDouble(txtWeight.Text);
                    int mpg = Convert.ToInt32(txtMpg.Text);
                    car = new Car(-1, make, model, color, weight, mpg);
                    carDao.Insert(car);
                    txtAddSucsses.Text = "Car added successfuly";
                }
                WipeOutControl();
                

                DisplayCars();
                btnAddCar.Text = "AddCAR";
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                txtErorr.Text = ex.Message.ToString();
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEdit = (Button)sender;
                RepeaterItem item = (RepeaterItem)btnEdit.NamingContainer;

                Label lblId = (Label)item.FindControl("lblId");
                Label lblMake = (Label)item.FindControl("lblMake");
                Label lblModel = (Label)item.FindControl("lblModel");
                Label lblColor = (Label)item.FindControl("lblColor");
                Label lblWeight = (Label)item.FindControl("lblWeight");
                Label lblMpg = (Label)item.FindControl("lblMpg");


                txtMake.Text = lblMake.Text;
                txtModel.Text = lblModel.Text;
                txtColor.Text = lblColor.Text;
                txtWeight.Text = lblWeight.Text;
                txtMpg.Text = lblMpg.Text;

                hdnId.Value = lblId.Text;

                btnAddCar.Text = "EditPerson";
                DisplayCars();

            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnEdit = (Button)sender;
                RepeaterItem item = (RepeaterItem)btnEdit.NamingContainer;

                Label lblId = (Label)item.FindControl("lblId");
                Car obj = new Car(Convert.ToInt32(lblId.Text), "", "", "", -1, -2);
                carDao.Delete(obj);
                txtAddSucsses.Text = "Car deleted successfuly";

                DisplayCars();


            }
            catch (DALException ex)
            {
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }

        }

    }
}