using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ev_Motor___Battery_CalCulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double gra = 9.81;
            double pie = Math.PI;
           
            double Required_speed = Convert.ToDouble(textBox1.Text);
            
            double Required_range = Convert.ToDouble(textBox2.Text);
           
            double loadToCarry = Convert.ToDouble(textBox3.Text);
            double RouteAvgInclinedAngle = Convert.ToDouble(textBox4.Text);
           
            double diameterOfWheel = Convert.ToDouble(textBox5.Text);
            double wheelRadius = diameterOfWheel * 0.0254 / 2;
            double coeficientOfLimitingFriction = Convert.ToDouble(textBox6.Text);
            double torque = (loadToCarry * gra * (Math.Sin(pie * RouteAvgInclinedAngle / 180)) * wheelRadius) / coeficientOfLimitingFriction;
            double wheelCircumference = pie * diameterOfWheel * 0.0254;
            double requiredRPM = Required_speed * 1000 / 60 / wheelCircumference;
            double power = (torque * requiredRPM * 2 * pie) / 60000;
            double coeficientOfAerodynamicFriction = Convert.ToDouble(textBox7.Text);
            double GearEfficiency = Convert.ToDouble(textBox8.Text) / 100;
            double MotorEfficiency = Convert.ToDouble(textBox9.Text) / 100;
            double requiredMotorInKW = power / GearEfficiency / coeficientOfAerodynamicFriction / MotorEfficiency;
            double RequiredVoltage = Convert.ToDouble(textBox10.Text);
            double cRatingOfBattery = Convert.ToDouble(textBox11.Text);
            double BatteryEfficiency = Convert.ToDouble(textBox12.Text) / 100;
            double requiredBattery;
            if (cRatingOfBattery >= 1)
            {
                requiredBattery = requiredMotorInKW / BatteryEfficiency / RequiredVoltage * Required_range / Required_speed * 1000;
            }
            else
            {
                requiredBattery = requiredMotorInKW / BatteryEfficiency / RequiredVoltage * Required_range / Required_speed / cRatingOfBattery * 1000;
            }
            textBox13.Text= requiredMotorInKW.ToString();
            textBox14.Text= requiredBattery.ToString();
        }
    }
}
