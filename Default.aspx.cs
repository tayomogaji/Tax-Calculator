using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Tax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void period_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void calculate_Click(object sender, EventArgs e)
    {
        try
        {
            //declearing total taxable income.
            double income = Convert.ToDouble(userIncome.Text);

            /* declearing variables for tax allowance and income margins.
             defult set to year */
            double taxFree = 11500;
            double highIncome = 45000;
            double addIncome = 150000;


            //optional month and week time frames included in switch satatment
            string timeFrame = (period.SelectedValue);
            double month = 12;
            double week = 52;


            switch (timeFrame)
            {
                //per month
                case "M":
                    taxFree = Math.Round(11500 / month, 2);
                    highIncome = Math.Round(45000 / month, 2);
                    addIncome = Math.Round(150000 / month, 2);
                    break;

                //per week
                case "W":
                    taxFree = Math.Round(11500 / week, 2);
                    highIncome = Math.Round(45000 / week, 2);
                    addIncome = Math.Round(150000 / week, 2);
                    break;
            }

            /*If the user is over the age of 65, a sum of £10600 will be added to the taxfree 
            total*/
            string pension = (age.SelectedValue);
            if (pension == "O")
            {
                taxFree = taxFree + 10600;
            }


            // calculating the Tax brackets
            double taxable = income - taxFree;

            double basic = Math.Round(income - (0.2 * taxable), 2);
            double basicTax = Math.Round(0.2 * taxable, 2);

            double high = Math.Round(income - (0.4 * taxable), 2);
            double highTax = Math.Round(0.4 * taxable, 2);

            double additional = Math.Round(income  - (0.45 * taxable), 2);
            double additionalTax = Math.Round(0.45 * taxable, 2);


            //calculating the NI according to income earnings.
            double plusNi = 0;
            if (ni.Checked)
            {
                if (income > taxFree && income < highIncome)
                {
                    plusNi = Math.Round(0.12 * taxable, 2);
                }
                else
                {
                    plusNi = Math.Round(0.2 * taxable, 2);
                }
            }

            double total;
            double totalTax;

            //tax free breakdown
            if (income <= taxFree)
            {
                afterTax.Text = ("£" + income + "");

                gross.Text = ("" + income + "");
                allowance.Text = ("£" + taxFree + "");
                taxableTotal.Text = ("£" + 0 + "");
                taxed.Text = ("£" + 0 + "");
                niTax.Text = ("£" + 0 + "");
                taxTotal.Text = ("£" + 0 + "");
            }

            //basic tax breakdown
            else if (income > taxFree && income < highIncome)
            {
                total = basic - plusNi;
                totalTax = basicTax + plusNi;

                afterTax.Text = ("£" + total + "");

                gross.Text = ("£" + income + "");
                allowance.Text = ("£" + taxFree + "");
                taxableTotal.Text = ("£" + taxable + "");
                taxed.Text = ("£" + basicTax + "");
                niTax.Text = ("£" + plusNi + "");
                taxTotal.Text = ("£" + totalTax + "");
            }

            //high tax breakdown
            else if (income > highIncome && income < addIncome)
            {
                total = high - plusNi;
                totalTax = highTax + plusNi;

                afterTax.Text = ("£" + total + "");

                gross.Text = ("£" + income + "");
                allowance.Text = ("£" + taxFree + "");
                taxableTotal.Text = ("£" + taxable + "");
                taxed.Text = ("£" + highTax + "");
                niTax.Text = ("£" + plusNi + "");
                taxTotal.Text = ("£" + totalTax + "");
            }

            //additional tax breakdown
            else if (income > addIncome)
            {
                total = high - plusNi;
                totalTax = additionalTax + plusNi;
                afterTax.Text = ("£" + total + "");

                gross.Text = ("£" + income + "");
                allowance.Text = ("£" + taxFree + "");
                taxableTotal.Text = ("£" + taxable + "");
                taxed.Text = ("£" + additionalTax + "");
                niTax.Text = ("£" + plusNi + "");
                taxTotal.Text = ("£" + totalTax + "");
            }

        }
        catch(Exception error)
        {
            errortext.Text = "Please type in your national gross income.";
        }
        
    }

    protected void ni_CheckedChanged(object sender, EventArgs e)
    {
         
    }

    protected void none_CheckedChanged(object sender, EventArgs e)
    {
        //noneLabel.Text = "I have no student loan debt.";
    }
}