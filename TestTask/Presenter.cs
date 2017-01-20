using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TestTask
{
    public class Presenter
    {
        private readonly Form1 view;
        private readonly Model model;

        public Presenter()
        {
            this.view = new Form1(this);
            try
            {
                this.model = new Model();

                view.SetStatusBox(model.GetStatusBoxFilling());

                view.SetDepsBox(model.GetDepsBoxFilling());

                view.SetPostsBox(model.GetPostsBoxFilling());

                view.SetPersonsDataGrid(
                    model.GetPersonsTable(
                        view.GetStatusBoxValue(),
                        view.GetDepsBoxValue(),
                        view.GetPostsBoxValue(),
                        view.GetSecondNameBoxValue()
                        )
                    );
            }
            catch (Exception e)
            {
                view.ShowMessageBox(e.Message);
                view.Exit();
            }            
        }

        public Form1 GetView()
        {
            return view;
        }

        public void UpdatePersonDataGrid(){
            try
            {
            view.SetPersonsDataGrid(
                    model.GetPersonsTable(
                        view.GetStatusBoxValue(),
                        view.GetDepsBoxValue(),
                        view.GetPostsBoxValue(),
                        view.GetSecondNameBoxValue()
                        )
                    );
            }
            catch (Exception e)
            {

            }  
        }

        public void UpdateStatisticDataGrid()
        {
            if (view.GetStartDate() <= view.GetEndDate())
            {
                try
                {
                    view.SetStatisticDataGrid(
                        model.GetStatisticTable(
                            view.GetStartDate(),
                            view.GetEndDate(),
                            view.RadioButtonEmployIsChecked()
                            )
                        );
                }
                catch (Exception e)
                {
                    view.ShowMessageBox(e.Message);
                }
            }
            else
            {
                view.ShowMessageBox("Начальная дата должна быть больше конечной, проверьте корректность введенных данных.");
            }
        }
        
    }
}
