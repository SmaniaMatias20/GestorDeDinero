using System;
using System.Windows.Forms;

namespace CapaPresentacion.Login
{
    public partial class UserControlPresentacion : UserControl
    {
        // Declaración de un evento que se dispara cuando la carga ha finalizado
        public event EventHandler CargaFinalizada;

        private const int TiempoTotal = 5; // Tiempo total en segundos
        private int tiempoTranscurrido = 0;

        public UserControlPresentacion()
        {
            InitializeComponent();

            timer1.Interval = 1000; // Intervalo del Timer en milisegundos (1 segundo)
            progressBar.Maximum = TiempoTotal; // Establece el valor máximo de la barra de progreso
        }

        private void UserControlPresentacion_Load(object sender, EventArgs e)
        {
            timer1.Start(); // Inicia el Timer cuando el formulario se carga
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tiempoTranscurrido++; // Incrementa el tiempo transcurrido

            // Actualiza la barra de progreso
            progressBar.Value = tiempoTranscurrido;

            // Si el tiempo transcurrido alcanza el tiempo total, detiene el Timer
            if (tiempoTranscurrido >= TiempoTotal)
            {
                timer1.Stop();

                // Dispara el evento de carga finalizada
                CargaFinalizada?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}
