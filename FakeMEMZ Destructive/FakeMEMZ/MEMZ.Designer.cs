
namespace FakeMEMZ
{
    partial class MEMZ
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.payload1 = new System.Windows.Forms.Timer(this.components);
            this.open_program = new System.Windows.Forms.Timer(this.components);
            this.cursor_movement = new System.Windows.Forms.Timer(this.components);
            this.payload2 = new System.Windows.Forms.Timer(this.components);
            this.flashing_screen = new System.Windows.Forms.Timer(this.components);
            this.random_error_sounds = new System.Windows.Forms.Timer(this.components);
            this.payload3 = new System.Windows.Forms.Timer(this.components);
            this.payload4 = new System.Windows.Forms.Timer(this.components);
            this.draw_error_icons = new System.Windows.Forms.Timer(this.components);
            this.draw_error_icons_2 = new System.Windows.Forms.Timer(this.components);
            this.tunnel_effect = new System.Windows.Forms.Timer(this.components);
            this.payload5 = new System.Windows.Forms.Timer(this.components);
            this.kill_windows = new System.Windows.Forms.Timer(this.components);
            this.Screen_Glitch = new System.Windows.Forms.Timer(this.components);
            this.Message_boxes = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // payload1
            // 
            this.payload1.Interval = 5000;
            this.payload1.Tick += new System.EventHandler(this.payload1_Tick);
            // 
            // open_program
            // 
            this.open_program.Interval = 20000;
            this.open_program.Tick += new System.EventHandler(this.open_program_Tick);
            // 
            // cursor_movement
            // 
            this.cursor_movement.Interval = 30;
            this.cursor_movement.Tick += new System.EventHandler(this.cursor_movement_Tick);
            // 
            // payload2
            // 
            this.payload2.Interval = 50000;
            this.payload2.Tick += new System.EventHandler(this.payload2_Tick);
            // 
            // flashing_screen
            // 
            this.flashing_screen.Interval = 1000;
            this.flashing_screen.Tick += new System.EventHandler(this.flashing_screen_Tick);
            // 
            // random_error_sounds
            // 
            this.random_error_sounds.Interval = 150;
            this.random_error_sounds.Tick += new System.EventHandler(this.random_error_sounds_Tick);
            // 
            // payload3
            // 
            this.payload3.Interval = 50000;
            this.payload3.Tick += new System.EventHandler(this.payload3_Tick);
            // 
            // payload4
            // 
            this.payload4.Interval = 50000;
            this.payload4.Tick += new System.EventHandler(this.payload4_Tick);
            // 
            // draw_error_icons
            // 
            this.draw_error_icons.Interval = 10;
            this.draw_error_icons.Tick += new System.EventHandler(this.draw_error_icons_Tick);
            // 
            // draw_error_icons_2
            // 
            this.draw_error_icons_2.Interval = 300;
            this.draw_error_icons_2.Tick += new System.EventHandler(this.draw_error_icons_2_Tick);
            // 
            // tunnel_effect
            // 
            this.tunnel_effect.Interval = 700;
            this.tunnel_effect.Tick += new System.EventHandler(this.tunnel_effect_Tick);
            // 
            // payload5
            // 
            this.payload5.Interval = 50000;
            this.payload5.Tick += new System.EventHandler(this.payload5_Tick);
            // 
            // kill_windows
            // 
            this.kill_windows.Interval = 50000;
            this.kill_windows.Tick += new System.EventHandler(this.kill_windows_Tick);
            // 
            // Screen_Glitch
            // 
            this.Screen_Glitch.Interval = 1800;
            this.Screen_Glitch.Tick += new System.EventHandler(this.Screen_Glitch_Tick);
            // 
            // Message_boxes
            // 
            this.Message_boxes.Interval = 10000;
            this.Message_boxes.Tick += new System.EventHandler(this.Message_boxes_Tick);
            // 
            // MEMZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MEMZ";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MEMZ";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MEMZ_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer payload1;
        private System.Windows.Forms.Timer open_program;
        private System.Windows.Forms.Timer cursor_movement;
        private System.Windows.Forms.Timer payload2;
        private System.Windows.Forms.Timer flashing_screen;
        private System.Windows.Forms.Timer random_error_sounds;
        private System.Windows.Forms.Timer payload3;
        private System.Windows.Forms.Timer payload4;
        private System.Windows.Forms.Timer draw_error_icons;
        private System.Windows.Forms.Timer draw_error_icons_2;
        private System.Windows.Forms.Timer tunnel_effect;
        private System.Windows.Forms.Timer payload5;
        private System.Windows.Forms.Timer kill_windows;
        private System.Windows.Forms.Timer Screen_Glitch;
        private System.Windows.Forms.Timer Message_boxes;
    }
}

