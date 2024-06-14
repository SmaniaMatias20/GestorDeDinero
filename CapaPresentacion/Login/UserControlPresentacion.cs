using System;
using System.Windows.Forms;

namespace CapaPresentacion.Login
{
    public partial class UserControlPresentacion : UserControl
    {
        // Atributos
        private const int TiempoTotal = 5; // Tiempo total en segundos
        private int tiempoTranscurrido = 0;

        // Declaración de un evento que se dispara cuando la carga ha finalizado
        public event EventHandler CargaFinalizada;

        /// <summary>
        /// Constructor de la clase UserControlPresentacion.
        /// Inicializa los componentes y configura el temporizador y la barra de progreso.
        /// </summary>
        public UserControlPresentacion()
        {
            // Llama al método InitializeComponent para inicializar todos los controles visuales definidos en el diseñador.
            InitializeComponent();
            // Intervalo del Timer en milisegundos (1 segundo)
            timer1.Interval = 1000;
            // Establece el valor máximo de la barra de progreso
            progressBar.Maximum = TiempoTotal; 
        }

        /// <summary>
        /// Este método se ejecuta cuando se carga el UserControl.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void UserControlPresentacion_Load(object sender, EventArgs e)
        {
            // Inicia el Timer cuando el formulario se carga
            timer1.Start(); 
        }

        /// <summary>
        /// Método que se ejecuta en cada tick del Timer.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Incrementa el tiempo transcurrido
            tiempoTranscurrido++; 

            // Actualiza la barra de progreso
            progressBar.Value = tiempoTranscurrido;

            // Si el tiempo transcurrido alcanza el tiempo total, detiene el Timer
            if (tiempoTranscurrido >= TiempoTotal)
            {
                // Detiene el Timer
                timer1.Stop();

                // Dispara el evento de carga finalizada
                CargaFinalizada?.Invoke(this, EventArgs.Empty);
            }

        }
    }
}
