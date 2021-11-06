
namespace FakeMEMZ_Clean
{
    partial class ControlPanel
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
            this.draw_error_icons_start = new System.Windows.Forms.CheckBox();
            this.draw_error_icons = new System.Windows.Forms.Timer(this.components);
            this.draw_error_icons_2 = new System.Windows.Forms.Timer(this.components);
            this.Tunnel_effect_start = new System.Windows.Forms.CheckBox();
            this.tunnel_effect = new System.Windows.Forms.Timer(this.components);
            this.flashing_screen_start = new System.Windows.Forms.CheckBox();
            this.flashing_screen = new System.Windows.Forms.Timer(this.components);
            this.open_program = new System.Windows.Forms.Timer(this.components);
            this.open_random_websites_programs_start = new System.Windows.Forms.CheckBox();
            this.random_cursor_movement = new System.Windows.Forms.Timer(this.components);
            this.Random_cursor_movement_start = new System.Windows.Forms.CheckBox();
            this.Random_error_sounds = new System.Windows.Forms.Timer(this.components);
            this.Screen_Glitch = new System.Windows.Forms.Timer(this.components);
            this.Random_error_sounds_start = new System.Windows.Forms.CheckBox();
            this.Language = new System.Windows.Forms.ComboBox();
            this.Message_boxes = new System.Windows.Forms.Timer(this.components);
            this.screen_glitches_start = new System.Windows.Forms.CheckBox();
            this.Message_boxes_start = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // draw_error_icons_start
            // 
            this.draw_error_icons_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.draw_error_icons_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.draw_error_icons_start.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.draw_error_icons_start.Location = new System.Drawing.Point(12, 118);
            this.draw_error_icons_start.Name = "draw_error_icons_start";
            this.draw_error_icons_start.Size = new System.Drawing.Size(285, 47);
            this.draw_error_icons_start.TabIndex = 3;
            this.draw_error_icons_start.Text = "Draw error icons";
            this.draw_error_icons_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.draw_error_icons_start.UseVisualStyleBackColor = true;
            this.draw_error_icons_start.CheckedChanged += new System.EventHandler(this.draw_error_icons_start_CheckedChanged);
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
            // Tunnel_effect_start
            // 
            this.Tunnel_effect_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.Tunnel_effect_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Tunnel_effect_start.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.Tunnel_effect_start.Location = new System.Drawing.Point(12, 171);
            this.Tunnel_effect_start.Name = "Tunnel_effect_start";
            this.Tunnel_effect_start.Size = new System.Drawing.Size(285, 47);
            this.Tunnel_effect_start.TabIndex = 4;
            this.Tunnel_effect_start.Text = "Tunnel effect";
            this.Tunnel_effect_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tunnel_effect_start.UseVisualStyleBackColor = true;
            this.Tunnel_effect_start.CheckedChanged += new System.EventHandler(this.Tunnel_effect_start_CheckedChanged);
            // 
            // tunnel_effect
            // 
            this.tunnel_effect.Interval = 700;
            this.tunnel_effect.Tick += new System.EventHandler(this.tunnel_effect_Tick);
            // 
            // flashing_screen_start
            // 
            this.flashing_screen_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.flashing_screen_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.flashing_screen_start.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.flashing_screen_start.Location = new System.Drawing.Point(12, 65);
            this.flashing_screen_start.Name = "flashing_screen_start";
            this.flashing_screen_start.Size = new System.Drawing.Size(285, 47);
            this.flashing_screen_start.TabIndex = 2;
            this.flashing_screen_start.Text = "Flashing screen";
            this.flashing_screen_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.flashing_screen_start.UseVisualStyleBackColor = true;
            this.flashing_screen_start.CheckedChanged += new System.EventHandler(this.flashing_screen_start_CheckedChanged);
            // 
            // flashing_screen
            // 
            this.flashing_screen.Interval = 1000;
            this.flashing_screen.Tick += new System.EventHandler(this.flashing_screen_Tick);
            // 
            // open_program
            // 
            this.open_program.Interval = 20000;
            this.open_program.Tick += new System.EventHandler(this.open_program_Tick);
            // 
            // open_random_websites_programs_start
            // 
            this.open_random_websites_programs_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.open_random_websites_programs_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.open_random_websites_programs_start.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.open_random_websites_programs_start.Location = new System.Drawing.Point(12, 12);
            this.open_random_websites_programs_start.Name = "open_random_websites_programs_start";
            this.open_random_websites_programs_start.Size = new System.Drawing.Size(285, 47);
            this.open_random_websites_programs_start.TabIndex = 1;
            this.open_random_websites_programs_start.Text = "Open random websites/programs";
            this.open_random_websites_programs_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.open_random_websites_programs_start.UseVisualStyleBackColor = true;
            this.open_random_websites_programs_start.CheckedChanged += new System.EventHandler(this.open_random_websites_programs_start_CheckedChanged);
            // 
            // random_cursor_movement
            // 
            this.random_cursor_movement.Interval = 30;
            this.random_cursor_movement.Tick += new System.EventHandler(this.random_cursor_movement_Tick);
            // 
            // Random_cursor_movement_start
            // 
            this.Random_cursor_movement_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.Random_cursor_movement_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Random_cursor_movement_start.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Random_cursor_movement_start.Location = new System.Drawing.Point(303, 12);
            this.Random_cursor_movement_start.Name = "Random_cursor_movement_start";
            this.Random_cursor_movement_start.Size = new System.Drawing.Size(285, 47);
            this.Random_cursor_movement_start.TabIndex = 5;
            this.Random_cursor_movement_start.Text = "Random cursor movement";
            this.Random_cursor_movement_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Random_cursor_movement_start.UseVisualStyleBackColor = true;
            this.Random_cursor_movement_start.CheckedChanged += new System.EventHandler(this.Random_cursor_movement_start_CheckedChanged);
            // 
            // Random_error_sounds
            // 
            this.Random_error_sounds.Interval = 180;
            this.Random_error_sounds.Tick += new System.EventHandler(this.Random_error_sounds_Tick);
            // 
            // Screen_Glitch
            // 
            this.Screen_Glitch.Interval = 1800;
            this.Screen_Glitch.Tick += new System.EventHandler(this.Glich_screen_Tick);
            // 
            // Random_error_sounds_start
            // 
            this.Random_error_sounds_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.Random_error_sounds_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Random_error_sounds_start.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Random_error_sounds_start.Location = new System.Drawing.Point(303, 65);
            this.Random_error_sounds_start.Name = "Random_error_sounds_start";
            this.Random_error_sounds_start.Size = new System.Drawing.Size(285, 47);
            this.Random_error_sounds_start.TabIndex = 6;
            this.Random_error_sounds_start.Text = "Random error sounds";
            this.Random_error_sounds_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Random_error_sounds_start.UseVisualStyleBackColor = true;
            this.Random_error_sounds_start.CheckedChanged += new System.EventHandler(this.Random_error_sounds_start_CheckedChanged);
            // 
            // Language
            // 
            this.Language.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Language.FormattingEnabled = true;
            this.Language.Items.AddRange(new object[] {
            "日本語",
            "English"});
            this.Language.Location = new System.Drawing.Point(498, 244);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(90, 26);
            this.Language.TabIndex = 7;
            this.Language.Text = "English";
            this.Language.SelectedIndexChanged += new System.EventHandler(this.Language_SelectedIndexChanged);
            // 
            // Message_boxes
            // 
            this.Message_boxes.Interval = 10000;
            this.Message_boxes.Tick += new System.EventHandler(this.Message_boxes_Tick);
            // 
            // screen_glitches_start
            // 
            this.screen_glitches_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.screen_glitches_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.screen_glitches_start.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.screen_glitches_start.Location = new System.Drawing.Point(303, 171);
            this.screen_glitches_start.Name = "screen_glitches_start";
            this.screen_glitches_start.Size = new System.Drawing.Size(285, 47);
            this.screen_glitches_start.TabIndex = 8;
            this.screen_glitches_start.Text = "Screen Glitches";
            this.screen_glitches_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.screen_glitches_start.UseVisualStyleBackColor = true;
            this.screen_glitches_start.CheckedChanged += new System.EventHandler(this.screen_glitches_start_CheckedChanged);
            // 
            // Message_boxes_start
            // 
            this.Message_boxes_start.Appearance = System.Windows.Forms.Appearance.Button;
            this.Message_boxes_start.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Message_boxes_start.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Message_boxes_start.Location = new System.Drawing.Point(303, 118);
            this.Message_boxes_start.Name = "Message_boxes_start";
            this.Message_boxes_start.Size = new System.Drawing.Size(285, 47);
            this.Message_boxes_start.TabIndex = 9;
            this.Message_boxes_start.Text = "Message boxes";
            this.Message_boxes_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Message_boxes_start.UseVisualStyleBackColor = true;
            this.Message_boxes_start.CheckedChanged += new System.EventHandler(this.Message_boxes_start_CheckedChanged);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(595, 282);
            this.Controls.Add(this.Message_boxes_start);
            this.Controls.Add(this.screen_glitches_start);
            this.Controls.Add(this.Language);
            this.Controls.Add(this.Random_error_sounds_start);
            this.Controls.Add(this.Random_cursor_movement_start);
            this.Controls.Add(this.open_random_websites_programs_start);
            this.Controls.Add(this.flashing_screen_start);
            this.Controls.Add(this.Tunnel_effect_start);
            this.Controls.Add(this.draw_error_icons_start);
            this.MaximizeBox = false;
            this.Name = "ControlPanel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FakeMEMZ Clean Version - Payload Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox draw_error_icons_start;
        private System.Windows.Forms.Timer draw_error_icons;
        private System.Windows.Forms.Timer draw_error_icons_2;
        private System.Windows.Forms.CheckBox Tunnel_effect_start;
        private System.Windows.Forms.Timer tunnel_effect;
        private System.Windows.Forms.Timer flashing_screen;
        private System.Windows.Forms.Timer open_program;
        private System.Windows.Forms.CheckBox open_random_websites_programs_start;
        private System.Windows.Forms.CheckBox flashing_screen_start;
        private System.Windows.Forms.Timer random_cursor_movement;
        private System.Windows.Forms.CheckBox Random_cursor_movement_start;
        private System.Windows.Forms.Timer Random_error_sounds;
        private System.Windows.Forms.Timer Screen_Glitch;
        private System.Windows.Forms.CheckBox Random_error_sounds_start;
        private System.Windows.Forms.ComboBox Language;
        private System.Windows.Forms.Timer Message_boxes;
        private System.Windows.Forms.CheckBox screen_glitches_start;
        private System.Windows.Forms.CheckBox Message_boxes_start;
    }
}

