using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AI_Project2GUI
{
    public partial class frm_RiverCross : Form
    {

        public class Record
        {
            public int[] States { get; set; }
            public List<int[]> Path { get; set; }
            public int Depth { get; set; }
            public Record()
            {
                States = new int[9];
                Path = new List<int[]>();
                Depth = 0;
            }
            public Record(int[] states)
            {
                States = new int[9];
                Path = new List<int[]>();
                Depth = 0;
                Array.Copy(states, States, 9);
            }

            public Record(int[] states, List<int[]> path)
            {
                States = new int[9];
                Path = new List<int[]>();
                Depth= 0;
                Array.Copy(states, States, 9);
                Path.AddRange(path);
            }
            public void ImportStates(int[] states)
            {
                if (states.Length != 9)
                {
                    throw new ArgumentException("States array must have a length of 9");
                }
                for (int i = 0; i < 9; i++)
                {
                    States[i] = states[i];
                }
            }
            public void AddToPath(int[] states)
            {
                Path.Add(states);
            }
            public override string ToString()
            {
                return string.Join(",", States);
            }
        }
        public List<Record> records = new List<Record>();
        public List<PictureBox> pictureBoxes = new List<PictureBox>();
        public Bitmap police = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\police (1).png");
        public Bitmap thief = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\thief (1).png");
        public Bitmap fahter = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\father.png");
        public Bitmap mother = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\mother.png");
        public Bitmap son1 = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\son1.png");
        public Bitmap son2 = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\son2.png");
        public Bitmap daughter1 = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\daughter1.png");
        public Bitmap daughter2 = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\daughter2.png");
        public Bitmap boat = new Bitmap("E:\\My_Codes\\Visual_Studio\\C#\\Ai_Class\\2\\GUI\\AI_Project2GUI\\AI_Project2GUI\\png\\boat.png");
        public int currentIndex = 0;
        public Timer timer;

        
        public frm_RiverCross()
        {
            InitializeComponent();
        }// GUI Codes

        private void frm_RiverCross_Load(object sender, EventArgs e)
        {
            
            pictureBoxes.Add(pbox_police_left);
            pictureBoxes.Add(pbox_thief_left);
            pictureBoxes.Add(pbox_father_left);
            pictureBoxes.Add(pbox_mother_left);
            pictureBoxes.Add(pbox_son1_left);
            pictureBoxes.Add(pbox_son2_left);
            pictureBoxes.Add(pbox_daughter1_left);
            pictureBoxes.Add(pbox_daughter2_left);
            pictureBoxes.Add(pbox_boat_left);
            pictureBoxes.Add(pbox_police_right);
            pictureBoxes.Add(pbox_thief_right);
            pictureBoxes.Add(pbox_father_right);
            pictureBoxes.Add(pbox_mother_right);
            pictureBoxes.Add(pbox_son1_right);
            pictureBoxes.Add(pbox_son2_right);
            pictureBoxes.Add(pbox_daughter1_right);
            pictureBoxes.Add(pbox_daughter2_right);
            pictureBoxes.Add(pbox_boat_right);


            pbox_police_left.Image = police;
            pbox_thief_left.Image = thief;
            pbox_father_left.Image = fahter;
            pbox_mother_left.Image = mother;
            pbox_son1_left.Image = son1;
            pbox_son2_left.Image = son2;
            pbox_daughter1_left.Image = daughter1;
            pbox_daughter2_left.Image = daughter2;
            pbox_boat_left.Image = boat;



          /*  for (int i = 0; i < 6; i++)
            {*/
                Record recording = new Record();
                /*int[][] createdStates = new int[][] {
                 new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                 new int[] { 1, 1, 1, 1, 1, 0, 1, 0, 1 },
                 new int[] { 1, 1, 1, 0, 1, 0, 1, 0, 0 },
                 new int[] { 1, 1, 0, 1, 1, 0, 1, 1, 1 },
                 new int[] { 0, 1, 0, 0, 1, 0, 1, 0, 1 },
                 new int[] { 0, 0, 0, 0, 0, 1, 0, 1, 0 },
                 new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 1 }
                };*/

                recording.ImportStates(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                records.Add(recording);

           /* }*/
            NUD_ShowIndex.Maximum = records.Count - 1;
            NUD_ShowIndex.Minimum = 0;

        } // GUI Codes

        public void Show(Record record)
        {
            // {Police,Theift,Father,Mother,Son1,Son2,Daughter1,Daughter2,Boat}
            for (int i = 0; i < record.States.Length; i++)
            {
                if (record.States[i] == 0)
                {
                    if (i == 0)
                    {
                        pbox_police_right.Image = null;
                        pbox_police_left.Image = police;
                    } else if (i == 1)
                    {
                        pbox_thief_right.Image = null;
                        pbox_thief_left.Image = thief;
                    } else if (i == 2)
                    {
                        pbox_father_right.Image = null;
                        pbox_father_left.Image = fahter;
                    } else if (i == 3)
                    {
                        pbox_mother_right.Image = null;
                        pbox_mother_left.Image = mother;
                    } else if (i == 4)
                    {
                        pbox_son1_right.Image = null;
                        pbox_son1_left.Image = son1;
                    } else if (i == 5)
                    {
                        pbox_son2_right.Image = null;
                        pbox_son2_left.Image = son2;
                    } else if (i == 6)
                    {
                        pbox_daughter1_right.Image = null;
                        pbox_daughter1_left.Image = daughter1;
                    } else if (i == 7)
                    {
                        pbox_daughter2_right.Image = null;
                        pbox_daughter2_left.Image = daughter2;
                    } else if (i == 8)
                    {
                        pbox_boat_right.Image = null;
                        pbox_boat_left.Image = boat;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        pbox_police_left.Image = null;
                        pbox_police_right.Image = police;
                    }
                    else if (i == 1)
                    {
                        pbox_thief_left.Image = null;
                        pbox_thief_right.Image = thief;
                    }
                    else if (i == 2)
                    {
                        pbox_father_left.Image = null;
                        pbox_father_right.Image = fahter;
                    }
                    else if (i == 3)
                    {
                        pbox_mother_left.Image = null;
                        pbox_mother_right.Image = mother;
                    }
                    else if (i == 4)
                    {
                        pbox_son1_left.Image = null;
                        pbox_son1_right.Image = son1;
                    }
                    else if (i == 5)
                    {
                        pbox_son2_left.Image = null;
                        pbox_son2_right.Image = son2;
                    }
                    else if (i == 6)
                    {
                        pbox_daughter1_left.Image = null;
                        pbox_daughter1_right.Image = daughter1;
                    }
                    else if (i == 7)
                    {
                        pbox_daughter2_left.Image = null;
                        pbox_daughter2_right.Image = daughter2;
                    }
                    else if (i == 8)
                    {
                        pbox_boat_left.Image = null;
                        pbox_boat_right.Image = boat;
                    }
                }
            }


        }
        
        public void ShowPath(List<Record> records)
        {
            try
            {
                int index = 0;
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000; // set the interval to 1 second
                timer.Tick += (sender, e) =>
                {
                    // check if we have reached the end of the list
                    if (index >= records.Count)
                    {
                        // stop the timer
                        timer.Stop();
                        return;
                    }

                    // update the UI with the current state
                    Show(records[index]);

                    // increment the index
                    index++;
                };
                timer.Start();
            }
            catch (NullReferenceException e)
            {
                // do nothing
            }
        }
        public Boolean IsValid(Record record)
        {
            int police = record.States[0];
            int thief = record.States[1];
            int father = record.States[2];
            int mother = record.States[3];
            int son1 = record.States[4];
            int son2 = record.States[5];
            int girl1 = record.States[6];
            int girl2 = record.States[7];
            int boatPos = record.States[8];

            // Condition 1: Only police or father or mother can drive the boat
            bool validDriver = (police == boatPos) || (father == boatPos) || (mother == boatPos);

            // Condition 2: Thief and police must always be in front of each other ot Thief is alone
            bool validThiefPolice = (thief == police) || (father != thief && police != thief && mother != thief && son1 != thief && son2 != thief && girl1 != thief && girl2 != thief && boatPos != thief);

            // Condition 3: If at least one son is with mother, father must also be with them
            //bool validParentsSon = (son1 != mother || father == mother || son1 == father) && (son2 != mother || father == mother || son2 == father);
            bool validParentsSon = ((mother == son1) || (mother == son2)) && (father == mother);
            // Condition 4: If at least one girl is with father, mother must also be with them
            //bool validParentsGirl = (girl1 != father || mother == father || girl1 == mother) && (girl2 != father || mother == father || girl2 == mother);
            bool validParentsGirl = ((father == girl1) || (father == girl2)) && (father == mother);
            
            return validDriver && validThiefPolice && validParentsSon && validParentsGirl;
        }
        public Boolean IsGoal(Record record)
        {
            if (Array.Equals(record.States , new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 })){
                return true;
            }else
                return false;
        }
        public List<Record> GenerateChildren(Record parent)
        {
            List<Record> ChilderenList = new List<Record>();
            if (!IsValid(parent))
            {
               MessageBox.Show("Isn't Valid!, Please Select a Valid State.", "Failed");
               return null;
            }
            else
            {// {Police,Theift,Father,Mother,Son1,Son2,Daughter1,Daughter2,Boat}
                var child = parent ;
                //Generate Childrens which only Driver is Crossing
                for (int j = 0; j <= 3; j++) //Drivers
                {
                        if (j == 1)//Delete Thieft Index
                            continue;
                        else
                        {
                            if (child.States[j] == child.States[8])
                            {
                                Record newChild1 = new Record(); // Create a new instance of Record
                                newChild1.ImportStates(child.States); // Copy the states from the original child
                                newChild1.States[j] = 1 - newChild1.States[j]; //State[j] Movement
                                newChild1.States[8] = 1 - newChild1.States[8]; //Boat Movement
                                newChild1.Path = new List<int[]>(child.Path);
                                newChild1.Path.Add(newChild1.States.ToArray());
                                newChild1.Depth = parent.Depth + 1; // set depth of child node
                                ChilderenList.Add(newChild1); // Add the new child to the list
                            }
                            else
                                continue;
                        }
                }
                // {Police,Theift,Father,Mother,Son1,Son2,Daughter1,Daughter2,Boat}
                for (int i = 0; i <= 3; i++)//Drivers
                {
                    if (i == 1)
                        continue;
                    for (int j = i+1; j <= 7; j++)//Everyone without Boat
                    {//j=i+1 Because we should remove the Duplicates
                        if (i != j)
                        {
                                if ((child.States[j] == child.States[8]) && (child.States[i] == child.States[j]))
                                {
                                    Record newChild2 = new Record(); // Create a new instance of Record
                                    newChild2.ImportStates(child.States); // Copy the states from the original child
                                    newChild2.States[i] = 1 - newChild2.States[i]; // Modify the new child's states
                                    newChild2.States[j] = 1 - newChild2.States[j];
                                    newChild2.States[8] = 1 - newChild2.States[8];
                                    newChild2.Path = new List<int[]>(child.Path);
                                    newChild2.Path.Add(newChild2.States.ToArray());
                                    newChild2.Depth = parent.Depth + 1; // set depth of child node
                                    ChilderenList.Add(newChild2); // Add the new child to the list
                                }
                                else
                                    continue;
                        }
                        else
                            continue;
                    }
                }
                /*for (int n = 0; n < ChilderenList.Count; n++)
                {
                    if (!IsValid(ChilderenList[n]))
                    {
                        ChilderenList.RemoveAt(n);
                        n = n - 1;
                    }

                }*/
                 return ChilderenList;
            }
        }


        public List<Record> DLS(Record root, int depth)
        {
            Stack Un = new Stack();
            LinkedList<int[]> Ex= new LinkedList<int[]>();
            Un.Push(root);
            Record n = new Record();
            while (Un.Count > 0)
            {
                n = (Record)Un.Pop();
                
                if (IsValid(n))
                {
                    if (IsGoal(n))
                    {
                        List<Record> GoalRecord = new List<Record>();
                        foreach (int[] states in n.Path)
                        {
                            Record record = new Record(states);
                            GoalRecord.Add(record);
                        }
                        GoalRecord.Add(n);
                        GoalRecord.Reverse();
                        return GoalRecord;
                    }
                    else
                    {
                        if (n.Depth <= depth && !Ex.Any(s => Enumerable.SequenceEqual(s, n.States)))
                        {
                            Ex.AddFirst(n.States);
                            var children = GenerateChildren(n);
                            for (int i = children.Count - 1; i >= 0; i--)
                            {
                                Un.Push(children[i]);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {

                }
            }
            return null;
        }
        private void btn_Show_Click(object sender, EventArgs e)
        {
            Show(records[Convert.ToInt32(NUD_ShowIndex.Text)]);
        }

        private void btn_ShowPath_Click(object sender, EventArgs e)
        {
            ShowPath(records);
        }

        private void btn_IsGool_Click(object sender, EventArgs e)
        {
            if (IsGoal(records[Convert.ToInt32(NUD_ShowIndex.Text)]))
            {
                MessageBox.Show("Is Goal!", "End of Crossing");
            }
            else
            {
                MessageBox.Show("There is No Goal!", "Crossing Failed");
            }

        }

        private void btn_IsValid_Click(object sender, EventArgs e)
        {
            if (IsValid(records[Convert.ToInt32(NUD_ShowIndex.Text)]))
            {
                MessageBox.Show("Is Valid!", "Successful");
            }
            else
            {
                MessageBox.Show("Isn't Valid!", "Failed");
            }
        }

        private void btn_ChildGen_Click(object sender, EventArgs e)
        {
            ShowPath(GenerateChildren(records[Convert.ToInt32(NUD_ShowIndex.Text)]));
        }

        private void btn_DLS_Click(object sender, EventArgs e)
        {
            Record root = new Record();
            root.States = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            root.Path.Add(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            root.Depth = 0;
            var turned = (DLS(root, 100000));
            if(turned != null)
            {
                ShowPath(turned);
            }
            else
            {
                MessageBox.Show("There is No Goal!", "Crossing Failed");
            }
        }
    }
}

