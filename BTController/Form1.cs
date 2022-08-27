using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using OpenJigWare;
using System.Management;


namespace BTController
{
    public partial class BTController : Form
    {

        #region variables

        string portSelected = "";
        int baudSelected = 9600;

        const int ARRAY_SIZE = 32;
        byte[] arrayToSend = new byte[ARRAY_SIZE];

        //List<string> buttons = new List<string>();
        List<Button> buttons = new List<Button>();
        List<RadioButton> calibBtns = new List<RadioButton>();
        List<string> calibKeys_ctrl = new List<string>();
        List<string> calibKeys_kb = new List<string>();
        List<Label> calibNames = new List<Label>();

        const int numOfButtons = 4;

        //Controller variable
        private Ojw.CJoystick m_CJoy = new Ojw.CJoystick(Ojw.CJoystick._ID_0); // Joystick Declaration
        
        #endregion variables

        public BTController()
        {
            InitializeComponent();
        }

        //Executes on form load
        private void BTController_Load(object sender, EventArgs e)
        {
            controllerTimer.Enabled = true;
            controllerTimer.Start();

            stickThreshold = 5;
            stickReverseThreshold = 10 - stickThreshold;

            foreach (Control control in groupBox1.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
            foreach (Control control in controlsGroupBox.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
            foreach (Control control in logGroupBox.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
            foreach (Control control in trackBarGroupBox.Controls)
            {
                control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
            }
            Ojw.CMessage.Init(logTextBox);
            getAvailablePorts();

            //creates radio buttons to replace buttons when calibrating
            foreach (Control ctrl in controlsGroupBox.Controls)
            {
                if (ctrl is Button)
                {
                    RadioButton rdioTemp = new RadioButton
                    {
                        Name = ctrl.Name + "_calib",
                        Text = "Press to reassign..",
                        Tag = ((Button)ctrl).Name,
                        Appearance = Appearance.Button,
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = ((Button)ctrl).Location,
                        Size = ((Button)ctrl).Size,
                        Visible = false,
                        Enabled = false,
                    };
                    rdioTemp.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    buttons.Add((Button)ctrl);
                    calibBtns.Add(rdioTemp);
                    controlsGroupBox.Controls.Add(rdioTemp);
                    calibKeys_kb.Add("Unassigned");
                    calibKeys_ctrl.Add("Unassigned");
                }
            }

            foreach (RadioButton rdio in calibBtns)
            {
                foreach (Control ctrl in controlsGroupBox.Controls)
                {
                    if (rdio.Tag == ctrl.Tag && ctrl is Label)
                    {
                        calibNames.Add((Label)ctrl);
                        break;
                    }
                }
            }




        }

        //Executes as form is closing
        private void BTController_Closing(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        //Makes sure only one item in list is checked at a time
        private void selectClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            foreach (var item in ((ToolStripMenuItem)clickedItem.OwnerItem).DropDownItems) {
                if (item != null)
                {
                    if (item.GetType() == typeof(ToolStripMenuItem))
                    {
                        ((ToolStripMenuItem)item).Checked = false;
                    }
                }
            }
            clickedItem.Checked = true;

            if ((ToolStripMenuItem)clickedItem.OwnerItem == selectToolStripMenuItem)
            {
                portSelected = clickedItem.Text;
            } else if ((ToolStripMenuItem)clickedItem.OwnerItem == baudRateToolStripMenuItem)
            {
                baudSelected = Convert.ToInt32(clickedItem.Text);
            }

        }

        //Gets available serial ports and adds them to port list
        private void getAvailablePorts()
        {
            String[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                ToolStripMenuItem[] items = new ToolStripMenuItem[ports.Length];
                for (int i = 0; i < items.Length; i++)
                {
                    logTextBox.AppendText(ports[i] + " detected.");
                    logTextBox.AppendText(Environment.NewLine);
                    items[i] = new ToolStripMenuItem();
                    items[i].Name = "dynamicItem" + i.ToString();
                    items[i].Text = ports[i];
                    items[i].Click += new EventHandler(selectClickHandler);
                }
                int counter = 0;
                foreach (ToolStripMenuItem item in items)
                {

                    selectToolStripMenuItem.DropDownItems.Insert(counter, item);
                    counter++;
                }
            }
            else
            {
                ToolStripLabel none = new ToolStripLabel();
                none.Name = "dynamicItemNone";
                none.Text = "(no ports detected)";
                none.Enabled = false;
                none.AutoSize = true;

                selectToolStripMenuItem.DropDownItems.Insert(0, none);

                ToolStripMenuItem placeHolder = new ToolStripMenuItem { Name = "placeholder" };
                selectToolStripMenuItem.DropDownItems.Insert(1, placeHolder);
                selectToolStripMenuItem.DropDownItems.RemoveByKey("placeholder");
            }
        }

        #region Speed control

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            speedTextBox.Text = speedTrackBar.Value.ToString();
        }


        private void speedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region MouseDown/MouseUp on buttons

        private void mouseDown(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                switch (((Button)sender).Name)
                {
                    case "leftBtn":
                        arrayToSend[3] = 1;
                        break;
                    case "rightBtn":
                        arrayToSend[4] = 1;
                        break;
                    case "fwdBtn":
                        arrayToSend[1] = 10;
                        break;
                    case "bwdBtn":
                        arrayToSend[2] = 7;
                        break;
                    default:
                        break;
                }
                sendData();
            }

        }

        private void mouseUp(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)
            {
                switch (((Button)sender).Name)
                {
                    case "leftBtn":
                        arrayToSend[3] = 0;
                        break;
                    case "rightBtn":
                        arrayToSend[4] = 0;
                        break;
                    case "fwdBtn":
                        arrayToSend[1] = 0;
                        break;
                    case "bwdBtn":
                        arrayToSend[2] = 0;
                        break;
                    default:
                        break;
                }
                sendData();
            }
        }

        #endregion

        #region KeyDown/KeyUp events

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyboardRdioBtn.Checked == true)
            {
                if (calibrateChkBox.Checked == false)
                {
                    try
                    {
                        if (serialPort1.IsOpen)
                        {
                            buttons[calibKeys_kb.IndexOf(e.KeyCode.ToString())].BackColor = SystemColors.GradientActiveCaption;
                            mouseDown(buttons[calibKeys_kb.IndexOf(e.KeyCode.ToString())], null);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyboardRdioBtn.Checked == true)
            {
                if (calibrateChkBox.Checked == true)
                {
                    foreach (RadioButton rdio in calibBtns)
                    {
                        if (rdio.Checked == false)
                        {
                            if (calibKeys_kb[calibBtns.IndexOf(rdio)] == e.KeyCode.ToString())
                            {
                                calibKeys_kb[calibBtns.IndexOf(rdio)] = "Unassigned";
                            }
                        }
                        else
                        {
                            rdio.Checked = false;
                            calibKeys_kb[calibBtns.IndexOf(rdio)] = e.KeyCode.ToString();
                        }
                    }

                    showAssingments();
                }
                else if (calibrateChkBox.Checked == false)
                {
                    try
                    {
                        if (serialPort1.IsOpen)
                        {
                            buttons[calibKeys_kb.IndexOf(e.KeyCode.ToString())].BackColor = SystemColors.Control;
                            mouseUp(buttons[calibKeys_kb.IndexOf(e.KeyCode.ToString())], null);
                        }
                    }
                    catch
                    {

                    }

                }
            }
        }

        #endregion

        //transmits data via serial
        private void sendData()
        {
            try
            {
                arrayToSend[0] = Convert.ToByte('s');
                arrayToSend[17] = 1;
                arrayToSend[ARRAY_SIZE - 1] = Convert.ToByte('f');
                serialPort1.Write(arrayToSend, 0, ARRAY_SIZE);
            }
            catch
            {
                logTextBox.AppendText("Error: Failed to send data!");
                logTextBox.AppendText(Environment.NewLine);
            }
        }

        //Disables keyboard assignment button navigation using arrow keys
        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        //Calibrte button press
        private void cailbrateChkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (calibrateChkBox.Checked == true)
            {
                keyboardRdioBtn.Enabled = false;
                controllerRdioBtn.Enabled = false;
                noneRdioBtn.Enabled = false;
                stickThreshold = 2;
                stickReverseThreshold = 10 - stickThreshold;
                //keyboard calibration
                if (keyboardRdioBtn.Checked == true)
                {
                    disableBtns();
                    hideBtns();
                    showCalib();
                    speedTextBox.Enabled = false;
                    speedTrackBar.Enabled = false;

                }
                else if (controllerRdioBtn.Checked == true)
                {

                    disableBtns();
                    hideBtns();
                    showCalib();
                    speedTextBox.Enabled = false;
                    speedTrackBar.Enabled = false;
                }
            }
            else if (calibrateChkBox.Checked == false)
            {
                stickThreshold = 5;
                stickReverseThreshold = 10 - stickThreshold;
                keyboardRdioBtn.Enabled = true;
                controllerRdioBtn.Enabled = true;
                noneRdioBtn.Enabled = true;
                hideCalib();
                showBtns();
                speedTextBox.Enabled = true;
                speedTrackBar.Enabled = true;

                if (serialPort1.IsOpen)
                {
                    enableBtns();
                }
                else
                {
                    disableBtns();
                }
            }
        }

        #region enable/disable/show/hide buttons

        private void enableBtns()
        {
            leftBtn.Enabled = true;
            rightBtn.Enabled = true;
            fwdBtn.Enabled = true;
            bwdBtn.Enabled = true;
        }

        private void disableBtns()
        {
            leftBtn.Enabled = false;
            rightBtn.Enabled = false;
            fwdBtn.Enabled = false;
            bwdBtn.Enabled = false;
        }

        private void showBtns()
        {
            leftBtn.Visible = true;
            rightBtn.Visible = true;
            fwdBtn.Visible = true;
            bwdBtn.Visible = true;
        }

        private void hideBtns()
        {
            leftBtn.Visible = false;
            rightBtn.Visible = false;
            fwdBtn.Visible = false;
            bwdBtn.Visible = false;
        }

        private void showCalib()
        {
            foreach (RadioButton rdio in calibBtns)
            {
                rdio.Enabled = true;
                rdio.Visible = true;
            }
        }

        private void hideCalib()
        {
            foreach (RadioButton rdio in calibBtns)
            {
                rdio.Enabled = false;
                rdio.Visible = false;
            }
        }

        #endregion enable/disable/show/hide buttons

        //Shows button assignments (for controller and/or keyboard)
        void showAssingments()
        {
            if (keyboardRdioBtn.Checked == true)
            {
                foreach (Label lbl in calibNames)
                {
                    lbl.Text = calibKeys_kb[calibNames.IndexOf(lbl)];
                }
                fwdLbl.Visible = true;
                bwdLbl.Visible = true;
                rightLbl.Visible = true;
                leftLbl.Visible = true;
            }
            else if (controllerRdioBtn.Checked == true)
            {
                foreach (Label lbl in calibNames)
                {
                    lbl.Text = calibKeys_ctrl[calibNames.IndexOf(lbl)];
                }
                fwdLbl.Visible = true;
                bwdLbl.Visible = true;
                rightLbl.Visible = true;
                leftLbl.Visible = true;


            }
            else if (noneRdioBtn.Checked == true)
            {
                fwdLbl.Visible = false;
                bwdLbl.Visible = false;
                rightLbl.Visible = false;
                leftLbl.Visible = false;
            }
        }

        /////////////////////////////////////////                 Controller Code                        //////////////////////////////////////

        #region variables

        bool checkPad = true;
        string lastState = "";

        int stickThreshold, stickReverseThreshold;

        const long stickMidpoint = 5;

        const long sliderMidpoint = 50;

        List<string> butsPressed = new List<string>();

        #endregion

        //Constantly checks if controller is alive
        private void FJoystick_Check_Alive()
        {
            if (m_CJoy.IsValid)
            {
                if (checkPad)
                {
                    logTextBox.AppendText("[OJW] Gamepad connected");
                    logTextBox.AppendText(Environment.NewLine);
                    controllerRdioBtn.Enabled = true;
                    checkPad = false;
                    lastState = "connected";
                }
                if (lastState == "disconnected")
                {
                    checkPad = true;
                }
            }
            else
            {
                if (checkPad)
                {
                    logTextBox.AppendText("[OJW] Gamepad not connected");
                    logTextBox.AppendText(Environment.NewLine);
                    controllerRdioBtn.Enabled = false;
                    if (controllerRdioBtn.Checked)
                    {
                        keyboardRdioBtn.Checked = true;
                    }
                    checkPad = false;
                    lastState = "disconnected";
                }
                if (lastState == "connected")
                {
                    checkPad = true;
                }
            }
        }

        //Executes every time "controllerTimer" timer ticks
        private void controllerTimer_Tick(object sender, EventArgs e)
        {
            m_CJoy.Update();
            FJoystick_Check_Alive();
            if (controllerRdioBtn.Checked == true)
            {
                FJoystick_Check_Data();
                if (calibrateChkBox.Checked == true)
                {
                    calibrateController(calibBtns, calibKeys_ctrl, butsPressed);
                }
            }

        }

        //Checks if any controller button is pressed and adds it to list of controller buttons/sticks/sliders(triggers) currently pressed
        private void checkAndAddBtnToList(Ojw.CJoystick pad, Ojw.CJoystick.PadKey Btn, List<string> lst)
        {
            if (pad.IsDown(Btn))
            {
                if (!(lst.Contains(Btn.ToString())))
                {
                    butsPressed.Add(Btn.ToString());
                    //logTextBox.AppendText(Btn.ToString() + " pressed");
                    //logTextBox.AppendText(Environment.NewLine);
                    butPressed(Btn);
                }
            }
            else if (pad.IsUp(Btn))
            {
                if (lst.Contains(Btn.ToString()))
                {
                    butsPressed.Remove(Btn.ToString());
                    //logTextBox.AppendText(Btn.ToString() + " depressed");
                    //logTextBox.AppendText(Environment.NewLine);
                    butReleased(Btn);
                }
            }
        }

        //Checks if any stick is moved and adds it to list of controller buttons/sticks/sliders(triggers) currently pressed
        private void checkAndAddStickToList(Ojw.CJoystick pad, List<string> lst, int numOfSticks)
        {
            if (numOfSticks == 1)
            {
                long x0 = Convert.ToInt64(10 * pad.dX0);
                long y0 = Convert.ToInt64(10 * pad.dY0);
                checkCalibrated("dY0_up", y0, stickMidpoint, 0);
                checkCalibrated("dY0_down", y0, stickMidpoint, 10);
                checkCalibrated("dX0_left", x0, stickMidpoint, 0);
                checkCalibrated("dX0_right", x0, stickMidpoint, 10);

                //First thumbstick
                #region up/down
                if (y0 == stickMidpoint)
                {
                    if (lst.Contains("dY0_up"))
                    {
                        lst.Remove("dY0_up");
                    }
                    if (lst.Contains("dY0_down"))
                    {
                        lst.Remove("dY0_down");
                    }
                }
                if (y0 < stickThreshold)
                {
                    if (!(lst.Contains("dY0_up")))
                    {
                        lst.Add("dY0_up");
                        //logTextBox.AppendText("stick 0 moved Up");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                else if (y0 > stickReverseThreshold)
                {
                    if (!(lst.Contains("dY0_down")))
                    {
                        lst.Add("dY0_down");
                        //logTextBox.AppendText("stick 0 moved Down");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                #endregion
                #region left/right
                if (x0 == stickMidpoint)
                {
                    if (lst.Contains("dX0_left"))
                    {
                        lst.Remove("dX0_left");
                    }
                    if (lst.Contains("dX0_right"))
                    {
                        lst.Remove("dX0_right");
                    }
                }
                if (x0 < stickThreshold)
                {
                    if (!(lst.Contains("dX0_left")))
                    {
                        lst.Add("dX0_left");
                        //logTextBox.AppendText("stick 0 moved Left");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                else if (x0 > stickReverseThreshold)
                {
                    if (!(lst.Contains("dX0_right")))
                    {
                        lst.Add("dX0_right");
                        //logTextBox.AppendText("stick 0 moved Right");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                #endregion
            }
            else if (numOfSticks == 2)
            {
                long x0 = Convert.ToInt64(10 * pad.dX0);
                long y0 = Convert.ToInt64(10 * pad.dY0);
                long x1 = Convert.ToInt64(10 * pad.dX1);
                long y1 = Convert.ToInt64(10 * pad.dY1);

                checkCalibrated("dY0_up", y0, stickMidpoint, 0);
                checkCalibrated("dY0_down", y0, stickMidpoint, 10);
                checkCalibrated("dX0_left", x0, stickMidpoint, 0);
                checkCalibrated("dX0_right", x0, stickMidpoint, 10);

                checkCalibrated("dY1_up", y1, stickMidpoint, 0);
                checkCalibrated("dY1_down", y1, stickMidpoint, 10);
                checkCalibrated("dX1_left", x1, stickMidpoint, 0);
                checkCalibrated("dX1_right", x1, stickMidpoint, 10);

                //First thumbstick
                #region up/down
                if (y0 == stickMidpoint)
                {
                    if (lst.Contains("dY0_up"))
                    {
                        lst.Remove("dY0_up");
                    }
                    if (lst.Contains("dY0_down"))
                    {
                        lst.Remove("dY0_down");
                    }
                }
                if (y0 < stickThreshold)
                {
                    if (!(lst.Contains("dY0_up")))
                    {
                        lst.Add("dY0_up");
                        //logTextBox.AppendText("stick 0 moved Up");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                else if (y0 > stickReverseThreshold)
                {
                    if (!(lst.Contains("dY0_down")))
                    {
                        lst.Add("dY0_down");
                        //logTextBox.AppendText("stick 0 moved Down");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                #endregion
                #region left/right
                if (x0 == stickMidpoint)
                {
                    if (lst.Contains("dX0_left"))
                    {
                        lst.Remove("dX0_left");
                    }
                    if (lst.Contains("dX0_right"))
                    {
                        lst.Remove("dX0_right");
                    }
                }
                if (x0 < stickThreshold)
                {
                    if (!(lst.Contains("dX0_left")))
                    {
                        lst.Add("dX0_left");
                        //logTextBox.AppendText("stick 0 moved Left");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                else if (x0 > stickReverseThreshold)
                {
                    if (!(lst.Contains("dX0_right")))
                    {
                        lst.Add("dX0_right");
                        //logTextBox.AppendText("stick 0 moved Right");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                #endregion

                //Second thumbstick
                #region up/down
                if (y1 == stickMidpoint)
                {
                    if (lst.Contains("dY1_up"))
                    {
                        lst.Remove("dY1_up");
                    }
                    if (lst.Contains("dY1_down"))
                    {
                        lst.Remove("dY1_down");
                    }
                }
                if (y1 < stickThreshold)
                {
                    if (!(lst.Contains("dY1_up")))
                    {
                        lst.Add("dY1_up");
                        //logTextBox.AppendText("stick 1 moved Up");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                else if (y1 > stickReverseThreshold)
                {
                    if (!(lst.Contains("dY1_down")))
                    {
                        lst.Add("dY1_down");
                        //logTextBox.AppendText("stick 1 moved Down");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                #endregion
                #region left/right
                if (x1 == stickMidpoint)
                {
                    if (lst.Contains("dX1_left"))
                    {
                        lst.Remove("dX1_left");
                    }
                    if (lst.Contains("dX1_right"))
                    {
                        lst.Remove("dX1_right");
                    }
                }
                if (x1 < stickThreshold)
                {
                    if (!(lst.Contains("dX1_left")))
                    {
                        lst.Add("dX1_left");
                        //logTextBox.AppendText("stick 1 moved Left");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                else if (x1 > stickReverseThreshold)
                {
                    if (!(lst.Contains("dX1_right")))
                    {
                        lst.Add("dX1_right");
                        //logTextBox.AppendText("stick 1 moved Right");
                        //logTextBox.AppendText(Environment.NewLine);
                    }
                }
                #endregion
            }

        }

        //Checks if any slider is moved and adds it to list of controller buttons/sticks/sliders(triggers) currently pressed
        private void checkAndAddSliderToList(Ojw.CJoystick pad, List<string> lst)
        {
            long slider = Convert.ToInt64(100 * pad.Slide);

            checkCalibrated("slider_r", slider, 50, 0);
            checkCalibrated("slider_l", slider, 50, 100);

            //Sliders
            #region Sliders
            if (slider == sliderMidpoint)
            {
                if (lst.Contains("slider_r"))
                {
                    lst.Remove("slider_r");
                }
                if (lst.Contains("slider_l"))
                {
                    lst.Remove("slider_l");
                }
            }
            if (slider < sliderMidpoint)
            {
                if (!(lst.Contains("slider_r")))
                {
                    lst.Add("slider_r");
                    //logTextBox.AppendText("stick 0 moved Up");
                    //logTextBox.AppendText(Environment.NewLine);
                    //checkCalibrated("slider_r");
                }
            }
            else if (slider > sliderMidpoint)
            {
                if (!(lst.Contains("slider_l")))
                {
                    lst.Add("slider_l");
                    //logTextBox.AppendText("stick 0 moved Down");
                    //logTextBox.AppendText(Environment.NewLine);
                    //checkCalibrated("slider_l");
                }
            }
            #endregion
        }

        //Checks controller data (goes through each button, stick, and slider (trigger))
        private void FJoystick_Check_Data()
        {
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button1, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button2, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button3, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button4, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button5, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button6, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button7, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button8, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button9, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button10, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button11, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button12, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button13, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button14, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button15, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button16, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button17, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button18, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button19, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button20, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button21, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button22, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button23, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button24, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button25, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button26, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button27, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button28, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button29, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.Button30, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.POVDown, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.POVLeft, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.POVRight, butsPressed);
            checkAndAddBtnToList(m_CJoy, Ojw.CJoystick.PadKey.POVUp, butsPressed);
            checkAndAddStickToList(m_CJoy, butsPressed, 1);
            checkAndAddSliderToList(m_CJoy, butsPressed);
        }

        //Calibrates controller
        private void calibrateController(List<RadioButton> formButtons, List<string> controllerCalibrationButtons, List<string> pressedButtons)
        {
            foreach (RadioButton rdio in formButtons)
            {
                if (rdio.Checked == true)
                {
                    if (pressedButtons.Count > 0)
                    {
                        string pressedBut = pressedButtons[0];
                        if (controllerCalibrationButtons.Contains(pressedBut)) controllerCalibrationButtons[controllerCalibrationButtons.IndexOf(pressedBut)] = "Unassigned";
                        controllerCalibrationButtons[formButtons.IndexOf(rdio)] = pressedBut;
                        rdio.Checked = false;
                        showAssingments();
                    }
                }
            }
        }

        //Clicks gui button on controller button pressed event
        private void butPressed(Ojw.CJoystick.PadKey Btn)
        {
            if (calibrateChkBox.Checked == false)
            {
                if (calibKeys_ctrl.Contains(Btn.ToString()))
                {
                    try
                    {
                        if (serialPort1.IsOpen)
                        {
                            buttons[calibKeys_ctrl.IndexOf(Btn.ToString())].BackColor = SystemColors.GradientActiveCaption;
                            mouseDown(buttons[calibKeys_ctrl.IndexOf(Btn.ToString())], null);
                        }
                    }
                    catch
                    {

                    }
                }
            }

        }

        //Releases gui button on controller button pressed event
        private void butReleased(Ojw.CJoystick.PadKey Btn)
        {
            if (calibrateChkBox.Checked == false)
            {
                if (calibKeys_ctrl.Contains(Btn.ToString()))
                {
                    try
                    {
                        if (serialPort1.IsOpen)
                        {
                            buttons[calibKeys_ctrl.IndexOf(Btn.ToString())].BackColor = SystemColors.ControlLight;
                            mouseUp(buttons[calibKeys_ctrl.IndexOf(Btn.ToString())], null);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        //Performs action on stick/slider(trigger) movement
        private void checkCalibrated(string control, long value, long min, long max)
        {
            double slopeR, slopeG, slopeB, interceptR, interceptG, interceptB, R, G, B, tempMin, tempMax;

            if (min < max)
            {
                tempMin = min;
                tempMax = max;
            }
            else
            {
                tempMin = max;
                tempMax = min;
            }

            Color col1 = SystemColors.ControlLight;
            Color col2 = SystemColors.GradientActiveCaption;

            if (calibKeys_ctrl.Contains(control) && serialPort1.IsOpen && calibrateChkBox.Checked == false && (value >= tempMin && value <= tempMax))
            {
                double colour1_R = (double)col1.R;
                double colour1_G = (double)col1.G;
                double colour1_B = (double)col1.B;
                double colour2_R = (double)col2.R;
                double colour2_G = (double)col2.G;
                double colour2_B = (double)col2.B;

                double xdiff = (double)max - (double)min;

                slopeR = (colour2_R - colour1_R) / xdiff;
                interceptR = colour1_R - (slopeR * (double)min);
                R = slopeR * (double)value + interceptR;

                slopeG = (colour2_G - colour1_G) / xdiff;
                interceptG = colour1_G - (slopeG * (double)min);
                G = slopeG * (double)value + interceptG;

                slopeB = (colour2_B - colour1_B) / xdiff;
                interceptB = colour1_B - (slopeB * (double)min);
                B = slopeB * (double)value + interceptB;

                buttons[calibKeys_ctrl.IndexOf(control)].BackColor = Color.FromArgb((int)R, (int)G, (int)B);
                sendControllerInfo(control);
                try
                {
                    sendData();
                }
                catch { }

            }
        }

        ////Sends controller info
        private void sendControllerInfo(string axis)
        {
            if (axis == "dY0_up" || axis == "dY0_down")
            {
                
            }
        }

        ////////////////////////////////////////////////////////////////         Event Methods         ////////////////////////////////////////////////////////////////

        private void noneRdioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                if (controllerTimer.Enabled == true)
                {
                    controllerTimer.Enabled = false;
                }
                calibrateChkBox.Enabled = false;
                showAssingments();
            }
            else if (((RadioButton)sender).Checked == false)
            {
                calibrateChkBox.Enabled = true;
            }
        }

        private void controllerRdioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                if (controllerTimer.Enabled == false)
                {
                    controllerTimer.Enabled = true;
                }

                showAssingments();
            }
        }

        private void keyboardRdioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                if (controllerTimer.Enabled == true)
                {
                    controllerTimer.Enabled = false;
                }
                showAssingments();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = portSelected;
                serialPort1.BaudRate = baudSelected;
            }
            catch
            {
                logTextBox.AppendText("Exception: Please select an available port!");
                logTextBox.AppendText(Environment.NewLine);
            }
            try
            {
                serialPort1.Open();
                logTextBox.AppendText(portSelected + " opened at ");
                logTextBox.AppendText(baudSelected.ToString() + " baud rate.");
                logTextBox.AppendText(Environment.NewLine);
                closeToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = false;
                refreshToolStripMenuItem.Enabled = false;
                enableBtns();
                int countDropDown = selectToolStripMenuItem.DropDownItems.Count;
                for (int i = 0; i < countDropDown; i++)
                {
                    if (selectToolStripMenuItem.DropDownItems[0].GetType() == typeof(ToolStripSeparator))
                    {
                        break;
                    }
                    else
                    {
                        selectToolStripMenuItem.DropDownItems[i].Enabled = false;
                    }

                }
                foreach (ToolStripMenuItem item in baudRateToolStripMenuItem.DropDownItems)
                {
                    item.Enabled = false;
                }
            }
            catch
            {
                logTextBox.AppendText("Exception: Cannot connect to port!");
                logTextBox.AppendText(Environment.NewLine);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countDropDown = selectToolStripMenuItem.DropDownItems.Count;
            for (int i = 0; i < countDropDown; i++)
            {
                if (selectToolStripMenuItem.DropDownItems[0].GetType() == typeof(ToolStripSeparator))
                {
                    break;
                }
                else
                {
                    selectToolStripMenuItem.DropDownItems.RemoveAt(0);
                }

            }
            getAvailablePorts();
            portSelected = "";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                refreshToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = false;
                logTextBox.AppendText(portSelected + " closed.");
                logTextBox.AppendText(Environment.NewLine);
                disableBtns();
                int countDropDown = selectToolStripMenuItem.DropDownItems.Count;
                for (int i = 0; i < countDropDown; i++)
                {
                    if (selectToolStripMenuItem.DropDownItems[0].GetType() == typeof(ToolStripSeparator))
                    {
                        break;
                    }
                    else
                    {
                        selectToolStripMenuItem.DropDownItems[i].Enabled = true;
                    }

                }
                foreach (ToolStripMenuItem item in baudRateToolStripMenuItem.DropDownItems)
                {
                    item.Enabled = true;
                }
            }
            catch
            {
                logTextBox.AppendText("Exception: Cannot close port!");
                logTextBox.AppendText(Environment.NewLine);
            }
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            checkPad = true;
            lastState = "";
            m_CJoy = new Ojw.CJoystick(Ojw.CJoystick._ID_0);
        }

    }
}

 