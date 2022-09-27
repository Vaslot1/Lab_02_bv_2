namespace Lab_02_bv_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtSequence.Text = Properties.Settings.Default.sequence;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = new Result();
            try
            {
                result = Result.Minmax(Logic.New_array(txtSequence.Text));
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            Properties.Settings.Default.sequence = txtSequence.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show(Logic.Min_Max(result));
        }
    }
    public class Logic
    {
        public static float[] New_array(string text)
        {
            string[] sequence = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            float[] arr = new float[sequence.Length];
            for(int i = 0; i<sequence.Length;i++)
            {
                arr[i] = float.Parse(sequence[i]);
            }
            return arr;
        }
        public static String Min_Max(Result result)
        {
            string s = "";
            if (result.max_1 != result.min_1 && result.max_2 != result.min_2 && result.max_1 != result.min_2 && result.max_2 != result.min_1)
            {
                s = "Первый минимум = " + result.min_1 + " Второй минимум = " + result.min_2 + " Первый максимум = " + result.max_1 + " Второй максимум = " + result.max_2;
            }
            else if (result.max_1 != result.min_1)
            {
                s = "Минимум = " + result.min_1 + " Максимум = " + result.max_1;
            }
            else
            {
                s = "Все элементы одинаковые";
            }
            return s;
        }
    }
    public class Result
    {
        public float max_1;
        public float max_2;
        public float min_1;
        public float min_2;
        public static Result Minmax(float[] arr)
        {
            float _max_1 = -99999999;
            float _max_2 = -99999999;
            float _min_1 = 99999999;
            float _min_2 = 99999999;
            int number = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > _max_1)
                {
                    _max_1 = arr[i];
                    number = i;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > _max_2 && i != number)
                {
                    _max_2 = arr[i];
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < _min_1)
                {
                    _min_1 = arr[i];
                    number = i;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < _min_2 && i != number)
                {
                    _min_2 = arr[i];
                }
            }
            return new Result { max_1 = _max_1, max_2 = _max_2, min_1 = _min_1, min_2 = _min_2 };
        }
    }
}