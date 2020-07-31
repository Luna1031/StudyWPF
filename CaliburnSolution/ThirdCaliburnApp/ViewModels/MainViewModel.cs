using Caliburn.Micro;
using Microsoft.Xaml.Behaviors.Media;
using MvvmDialogs;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows;
using ThirdCaliburnApp.Helpers;
using ThirdCaliburnApp.Models;

namespace ThirdCaliburnApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {

        #region 속성영역

        readonly IWindowManager windowManager;
        readonly IDialogService dialogService;

        private BindableCollection<EmployeesModel> employees;

        //전체 Employee 리스트
        public BindableCollection<EmployeesModel> Employees 
        { 
            get => employees;
            set 
            {
                employees = value;
                NotifyOfPropertyChange(() => Employees);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            } 
        }


        //선택된 하나의 Employee
        EmployeesModel selectedEmployee;

        public EmployeesModel SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;

                if (value != null)
                {
                    Id = value.Id;
                    EmpName = value.EmpName;
                    Salary = value.Salary;
                    DeptName = value.DeptName;
                    Destination = value.Destination;
                }
                NotifyOfPropertyChange(() => SelectedEmployee);
                NotifyOfPropertyChange(() => CanSaveEmployee);

            }
        }

        int id;

        public int Id
        {
            get => id;
            set
            {
                id = value;
                NotifyOfPropertyChange(() => Id);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        string empName;

        public string EmpName 
        {
            get => empName;
            set 
            {
                empName = value;
                NotifyOfPropertyChange(() => EmpName);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        decimal salary;
        public decimal Salary
        {
            get => salary;
            set
            {
                salary = value;
                NotifyOfPropertyChange(() => Salary);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        string deptName;
        public string DeptName
        {
            get => deptName;
            set
            {
                deptName = value;
                NotifyOfPropertyChange(() => DeptName);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }

        string destination;
        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                NotifyOfPropertyChange(() => Destination);
                NotifyOfPropertyChange(() => CanSaveEmployee);
            }
        }
        #endregion

        #region 생성자
      
        public MainViewModel(IWindowManager windowManager, IDialogService dialogService)
        {
            this.windowManager = windowManager;
            this.dialogService = dialogService;
            GetEmployees();
        }

        #endregion

        public void GetEmployees()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECT_EMPLYEES, conn);
                //cmd.Connection = conn;
                //커멘드가 커넥션으로 이어진다는것을 보여줘야됨
                MySqlDataReader reader = cmd.ExecuteReader();
                Employees = new BindableCollection<EmployeesModel>();

                while (reader.Read())
                {
                    var temp = new EmployeesModel
                    {
                        Id = (int)reader["id"], //[employsTBL속성값]
                        EmpName = reader["empName"].ToString(),
                        Salary = (decimal)reader["Salary"],
                        DeptName = reader["DeptName"].ToString(),
                        Destination = reader["Destination"].ToString()
                    };
                    Employees.Add(temp);
                }
            }
        }
        public void SaveEmployee()
        {
            int resultRow = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    if (Id == 0)//Insert
                        cmd.CommandText = Commons.INSERT_EMPLYEE;
                    else
                        cmd.CommandText = Commons.UPDATE_EMPLYEE;


                    MySqlParameter paramEmpName = new MySqlParameter("@EmpName", MySqlDbType.VarChar, 45);
                    paramEmpName.Value = EmpName;
                    cmd.Parameters.Add(paramEmpName);

                    MySqlParameter paramsalary = new MySqlParameter("@salary", MySqlDbType.Decimal);
                    paramsalary.Value = Salary;
                    cmd.Parameters.Add(paramsalary);

                    MySqlParameter paramDeptName = new MySqlParameter("@DeptName", MySqlDbType.VarChar, 45);
                    paramDeptName.Value = DeptName;
                    cmd.Parameters.Add(paramDeptName);

                    MySqlParameter paramDestination = new MySqlParameter("@Destination", MySqlDbType.VarChar, 45);
                    paramDestination.Value = Destination;
                    cmd.Parameters.Add(paramDestination);

                    if (Id != 0)
                    {
                        MySqlParameter paramId = new MySqlParameter("@id", MySqlDbType.Int32);
                        paramId.Value = Id;
                        cmd.Parameters.Add(paramId);
                    }

                    resultRow = cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                DialogViewModel dialogVM = new DialogViewModel();
                dialogVM.DisplayName = $"{ex.Message}";
                bool? success = windowManager.ShowDialog(dialogVM);
            }
            if (resultRow > 0)
            {
                // MessageBox.Show("저장");
                DialogViewModel dialogVM = new DialogViewModel();
                dialogVM.DisplayName = "저장";
                bool? success = windowManager.ShowDialog(dialogVM);

                GetEmployees();
                NewEmployee();
            }
        }
        public bool CanSaveEmployee
        {
            get => !(string.IsNullOrEmpty(EmpName) ||
                    string.IsNullOrEmpty(DeptName) ||
                    string.IsNullOrEmpty(Destination) ||
                    Salary == 0);
        }
        public void NewEmployee()
        {
            Id = 0;
            EmpName = string.Empty;
            DeptName = string.Empty;
            Destination = string.Empty;
            Salary = 0;
        }

        public bool CanDeleteEmployee
        {
            get => (Id == 0);
        }

        public void DeleteEmployee()
        {
            int resultRow = 0;

            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTRING))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Commons.DELETE_EMPLYEE;


                MySqlParameter paramId= new MySqlParameter("@id", MySqlDbType.Int32);
                paramId.Value = Id;
                cmd.Parameters.Add(paramId);

                resultRow = cmd.ExecuteNonQuery();
            }

            if(resultRow > 0)
            {
                MessageBox.Show("삭제");
                NewEmployee();
                GetEmployees();
            }
        }
    }
}
