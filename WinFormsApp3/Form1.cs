using System.Runtime.CompilerServices;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        // Списки для хранения врагов и ловушек
        List<Enemy> enemies = new List<Enemy>();
        List<Trap> traps = new List<Trap>();

        // Сам игрок
        Player player = new Player();

        // Рандом для случайных движений врагов
        Random random = new Random();

        // Игровые параметры
        int score = 0;
        int maxTraps = 10;  // Максимальное количество ловушек
        int trapsLeft;      // Сколько ловушек осталось
        bool gameOver = false;
        private object payer;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveEnemies();
            CheckCollisions();
            gamePanel.Invalidate(); // Перерисовать панель
        }
        private void StartGame()
        {
            // Создаем игрока по центру поля
            player = new Player { Position = new Point(200, 200) };

            // Очищаем врагов и ловушки
            enemies.Clear();
            traps.Clear();

            // Сброс очков и ловушек
            score = 0;
            trapsLeft = maxTraps;
            gameOver = false;

            // Добавляем одного стартового врага
            AddEnemy();

            // Обновляем интерфейс
            scoreLable.Text = "Счет: 0";
            trapsLable.Text = $"Ловушки: {trapsLeft}";

            // Запускаем таймер игры
            gameTimer.Start();
        }
        private void AddEnemy()
        {
            enemies.Add(new Enemy
            {
                Position = new Point(random.Next(0, gamePanel.Width - 15), random.Next(0, gamePanel.Height - 15)),
                Direction = new Point(random.Next(-1, 2), random.Next(-1, 2))  // Случайное направление
            });
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void MoveEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.Position = new Point(enemy.Position.X + enemy.Direction.X * 2, enemy.Position.Y + enemy.Direction.Y * 2);

                // Проверка выхода за границы
                if (enemy.Position.X < 0 || enemy.Position.X > gamePanel.Width - enemy.Size)
                    enemy.Direction = new Point(-enemy.Direction.X, enemy.Direction.Y);
                if (enemy.Position.Y < 0 || enemy.Position.Y > gamePanel.Height - enemy.Size)
                    enemy.Direction = new Point(enemy.Direction.X, -enemy.Direction.Y);
            }
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (player != null)
                g.FillRectangle(Brushes.Blue, player.Position.X, player.Position.Y, player.Size, player.Size);

            foreach (var trap in traps)
                g.FillRectangle(Brushes.Black, trap.Position.X, trap.Position.Y, trap.Size, trap.Size);

            foreach (var enemy in enemies)
                g.FillRectangle(Brushes.Red, enemy.Position.X, enemy.Position.Y, enemy.Size, enemy.Size);
        }
         
        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;

            switch (e.KeyCode)
            {
                case Keys.A:
                    player.Position = new Point(Math.Max(0, player.Position.X - 20), player.Position.Y);
                    break;
                case Keys.D:
                    player.Position = new Point(Math.Min(gamePanel.Width - player.Size, player.Position.X + 20), player.Position.Y);
                    break;
                case Keys.W:
                    player.Position = new Point(player.Position.X, Math.Max(0, player.Position.Y - 20));
                    break;
                case Keys.S:
                    player.Position = new Point(player.Position.X, Math.Min(gamePanel.Height - player.Size, player.Position.Y + 20));
                    break;
                case Keys.Space:
                    if (trapsLeft > 0)
                    {
                        traps.Add(new Trap { Position = new Point(player.Position.X, player.Position.Y) });
                        trapsLeft--;
                        trapsLable.Text = $"Ловушки: {trapsLeft}";
                    }
                    break;
            }
        }

        private void CheckCollisions()
        {
            // Столкновение персонажа с врагами
            foreach (var enemy in enemies)
            {
                if (IsCollision(player.Position, player.Size, enemy.Position, enemy.Size))
                {
                    GameOver();
                    return;
                }
            }

            // Столкновение врагов с ловушками
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                foreach (var trap in traps)
                {
                    if (IsCollision(enemies[i].Position, enemies[i].Size, trap.Position, trap.Size))
                    {
                        enemies.RemoveAt(i);
                        score++;
                        scoreLable.Text = $"Счет: {score}";
                        if (score % 5 == 0) AddEnemy(); // Каждые 5 очков добавляется новый враг
                        return;
                    }
                }
            }
        }
        private bool IsCollision(Point pos1, int size1, Point pos2, int size2)
        {
            Rectangle r1 = new Rectangle(pos1.X, pos1.Y, size1, size1);
            Rectangle r2 = new Rectangle(pos2.X, pos2.Y, size2, size2);
            return r1.IntersectsWith(r2);
        }
        private void GameOver()
        {
            gameTimer.Stop();
            gameOver = true;
            MessageBox.Show("Игра окончена!");
        }
    }
}
