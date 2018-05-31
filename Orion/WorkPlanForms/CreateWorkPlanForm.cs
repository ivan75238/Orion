using GlobalLib;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Orion.WorkPlanForms
{
    public partial class CreateWorkPlanForm : MetroForm
    {
        WorkPlan plan;
        User user;
        public CreateWorkPlanForm()
        {
            InitializeComponent();
            user = User.GetInstance();
        }
        public CreateWorkPlanForm(WorkPlan _plan)
        {
            InitializeComponent();
            plan = _plan;
            TextBoxJanuary.Text = plan.january.ToString();
            TextBoxFebruary.Text = plan.february.ToString();
            TextBoxMarch.Text = plan.march.ToString();
            TextBoxApril.Text = plan.april.ToString();
            TextBoxMay.Text = plan.may.ToString();
            TextBoxJune.Text = plan.june.ToString();
            TextBoxJule.Text = plan.july.ToString();
            TextBoxAugust.Text = plan.august.ToString();
            TextBoxSeptember.Text = plan.september.ToString();
            TextBoxOctober.Text = plan.october.ToString();
            TextBoxNovember.Text = plan.november.ToString();
            TextBoxDecember.Text = plan.december.ToString();
            DateTimePickerYear.Value = plan.year;
        }

        private void TextBoxJanuary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {

            if (TextBoxJanuary.Text != "")
            {
                if (TextBoxFebruary.Text != "")
                {
                    if (TextBoxMarch.Text != "")
                    {
                        if (TextBoxApril.Text != "")
                        {
                            if (TextBoxMay.Text != "")
                            {
                                if (TextBoxJune.Text != "")
                                {
                                    if (TextBoxJule.Text != "")
                                    {
                                        if (TextBoxAugust.Text != "")
                                        {
                                            if (TextBoxSeptember.Text != "")
                                            {
                                                if (TextBoxOctober.Text != "")
                                                {
                                                    if (TextBoxNovember.Text != "")
                                                    {
                                                        if (TextBoxDecember.Text != "")
                                                        {
                                                            if (plan == null)
                                                            {
                                                                new WorkPlan
                                                                {
                                                                    year = DateTimePickerYear.Value,
                                                                    january = Convert.ToInt32(TextBoxJanuary.Text),
                                                                    february = Convert.ToInt32(TextBoxFebruary.Text),
                                                                    march = Convert.ToInt32(TextBoxMarch.Text),
                                                                    april = Convert.ToInt32(TextBoxApril.Text),
                                                                    may = Convert.ToInt32(TextBoxMay.Text),
                                                                    june = Convert.ToInt32(TextBoxJune.Text),
                                                                    july = Convert.ToInt32(TextBoxJule.Text),
                                                                    august = Convert.ToInt32(TextBoxAugust.Text),
                                                                    september = Convert.ToInt32(TextBoxSeptember.Text),
                                                                    october = Convert.ToInt32(TextBoxOctober.Text),
                                                                    november = Convert.ToInt32(TextBoxNovember.Text),
                                                                    december = Convert.ToInt32(TextBoxDecember.Text),
                                                                }.Create();
                                                                MetroMessageBox.Show(this, "План добавлен!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                                                Close();
                                                            }
                                                            else
                                                            {
                                                                new WorkPlan
                                                                {
                                                                    id = plan.id,
                                                                    year = DateTimePickerYear.Value,
                                                                    january = Convert.ToInt32(TextBoxJanuary.Text),
                                                                    february = Convert.ToInt32(TextBoxFebruary.Text),
                                                                    march = Convert.ToInt32(TextBoxMarch.Text),
                                                                    april = Convert.ToInt32(TextBoxApril.Text),
                                                                    may = Convert.ToInt32(TextBoxMay.Text),
                                                                    june = Convert.ToInt32(TextBoxJune.Text),
                                                                    july = Convert.ToInt32(TextBoxJule.Text),
                                                                    august = Convert.ToInt32(TextBoxAugust.Text),
                                                                    september = Convert.ToInt32(TextBoxSeptember.Text),
                                                                    october = Convert.ToInt32(TextBoxOctober.Text),
                                                                    november = Convert.ToInt32(TextBoxNovember.Text),
                                                                    december = Convert.ToInt32(TextBoxDecember.Text),
                                                                }.Edit();
                                                                MetroMessageBox.Show(this, "Изменения сохранены!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                                                Close();
                                                            }
                                                        }
                                                        else
                                                            MetroMessageBox.Show(this, "Заполните план на декабрь", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                                    }
                                                    else
                                                        MetroMessageBox.Show(this, "Заполните план на ноябрь", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                                }
                                                else
                                                    MetroMessageBox.Show(this, "Заполните план на октябрь", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                            }
                                            else
                                                MetroMessageBox.Show(this, "Заполните план на сентябрь", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                        }
                                        else
                                            MetroMessageBox.Show(this, "Заполните план на август", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                    }
                                    else
                                        MetroMessageBox.Show(this, "Заполните план на июль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                                else
                                    MetroMessageBox.Show(this, "Заполните план на июнь", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
                            else
                                MetroMessageBox.Show(this, "Заполните план на май", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        }
                        else
                            MetroMessageBox.Show(this, "Заполните план на апрель", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                        MetroMessageBox.Show(this, "Заполните план на март", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                    MetroMessageBox.Show(this, "Заполните план на февраль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
                MetroMessageBox.Show(this, "Заполните план на январь", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
