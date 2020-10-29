using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDemo2.cs
{
    class Program

    {

        static void Main(string[] args)

        {

            InsuredPatient[] insuredPatientArr = new InsuredPatient[5];

            double totalAmtDue = 0;

            for (int i = 0; i < 5; i++)
            {
                insuredPatientArr[i] = new InsuredPatient();

                WriteLine("Enter Patient Id");
                insuredPatientArr[i].IdNumb = Convert.ToInt32(ReadLine());

                WriteLine("Enter Patient Name");
                insuredPatientArr[i].Name = ReadLine();

                WriteLine("Enter Patient Age");
                insuredPatientArr[i].Age = Convert.ToInt32(ReadLine());

                WriteLine("Enter Amount Due");
                insuredPatientArr[i].AmountDue = Convert.ToDouble(ReadLine());

                WriteLine("Enter Company Name");
                insuredPatientArr[i].Ins_Company_Name = ReadLine();

                totalAmtDue += insuredPatientArr[i].AmountDue;

            }
            //Sort insured patients
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (insuredPatientArr[x].IdNumb < insuredPatientArr[y].IdNumb)
                    {
                        InsuredPatient temp = insuredPatientArr[y];
                        insuredPatientArr[y] = insuredPatientArr[x];
                        insuredPatientArr[x] = temp;
                    }
                }
            }

            //display
            for (int i = 0; i < 5; i++)
            {
                WriteLine(insuredPatientArr[i].ToString());
            }
            WriteLine("Total Due Amount:{0}", totalAmtDue);
            ReadLine();
        }
    }

    class Patient
    {
        private int idNumb;
        private string name;
        private int age;
        private double amountDue;

        public int IdNumb { get { return idNumb; } set { idNumb = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public double AmountDue { get { return amountDue; } set { amountDue = value; } }//this is the amount due to the hospital

        public override string ToString()
        {
            string details = "Patient name: " + name + "\n";
            details += "Patient ID number: " + idNumb + "\n";
            details += "Patient age: " + age + "\n";
            details += "Patient amount due: " + amountDue + "\n";
            return details;
        }
    }
        class InsuredPatient : Patient
        {
            string insurance_Company_Name;
            double percent_paid;
            public double Percent_paid
            {
                get { return percent_paid; }
                set { percent_paid = value; }
            }

            public string Ins_Company_Name
            {
                get { return insurance_Company_Name; }

                set
                {
                    insurance_Company_Name = value;
                    if (insurance_Company_Name.Equals("Wrightstown Mutual"))
                        percent_paid = 80.0;
                    else if (insurance_Company_Name.Equals("Red Umbrella"))
                        percent_paid = 60.0;
                    else
                        percent_paid = 25.0;
                }
            }

            public override string ToString()
            {
                return "\n\nPatient ID: " + IdNumb + " \n Patient Name: " + Name + " \n Age: " + Age + " \n Insurance Company Name: " + Ins_Company_Name + 
                    "\n Percentage Paid " + Percent_paid + "\n amount due after insurance" + (AmountDue * ((100 - Percent_paid) / 100.0));
            }
        }
}


