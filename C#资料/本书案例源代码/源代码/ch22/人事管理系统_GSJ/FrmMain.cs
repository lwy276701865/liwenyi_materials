using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//
using GSJ_Descryption;
namespace 人事管理系统_GSJ
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        #region 公用字段和属性
        private static bool p_isSucessLoad = false;//判断是否成功登陆
        public static bool P_isSucessLoad
        {
            get { return FrmMain.p_isSucessLoad; }
            set { FrmMain.p_isSucessLoad = value; }
        }

        private static string p_currentUserName = "";//当前用户名
        public static string P_currentUserName
        {
            get { return FrmMain.p_currentUserName; }
            set { FrmMain.p_currentUserName = value; }
        }
        private static bool p_haveDAAccess = false;//是否有对人事档案管理的权限

        public static bool P_haveDAAccess //目的是为了防止查询时调用没有权限的人事档案管理模块
        {
            get { return FrmMain.p_haveDAAccess; }
            set { FrmMain.p_haveDAAccess = value; }
        }
 #endregion
        private void FrmMain_Load(object sender, EventArgs e)
        {
           

            //输入用户登陆信息
            FrmLoad frm_load = new FrmLoad();
            frm_load.ShowDialog();
            frm_load.Dispose();
            //判断结果
            if (P_isSucessLoad)//成功登陆
            {
                
                //设置权限
                SettingMenu();
                //显示当前用户
                tssl_userName.Text = P_currentUserName;
//窗体设为最大
                this.WindowState = FormWindowState.Maximized;
                //todo:显示提醒
               

            }
            else //登陆失败关闭程序
            {
                Application.Exit();
            }
        }
        private void SettingMenu() //根据权限设置菜单
        {
            #region 第一步:读取用户权限
            GSJ_DESC mydesc = new GSJ_DESC("@gsj");                            //加密用户名
            string sql = "select PopeName,Pope from tb_UserPope where Uid='" +mydesc.Encry( p_currentUserName) + "'";
            DataSet popeDs = new DataSet();//存权限信息
            try
            {
                MyDBControls.GetConn();
                popeDs = MyDBControls.GetDataSet(sql);//提取权限信息
                MyDBControls.CloseConn();
            }
            catch
            {

                
                Application.Exit();//用户权限未知,为了安全退出程序
            }
            #endregion
            #region 第二步:设置相应菜单状态
            for (int x = 0; x < popeDs.Tables[0].Rows.Count; x++)
            {
                string popeName = popeDs.Tables[0].Rows[x][0].ToString();//权限名
                bool popeState = true;
                if (popeDs.Tables[0].Rows[x][1].ToString() == "False") //权限是否能用
                {
                    popeState = false;
                }
                for (int i = 0; i < msp_mainMenu.Items.Count; i++)//一级菜单
                {
                    if (msp_mainMenu.Items[i].Text.IndexOf(popeName) != -1)//设置状态
                    {
                        msp_mainMenu.Items[i].Enabled = popeState;
                    }
                    ToolStripDropDownItem tsdd1 = (ToolStripDropDownItem)msp_mainMenu.Items[i];//一级菜单的下级集合
                    if (tsdd1.HasDropDownItems && tsdd1.DropDownItems.Count > 0)//判断是否有二级菜单
                    {
                        for (int ii = 0; ii < tsdd1.DropDownItems.Count; ii++) //二级菜单
                        {
                            if (tsdd1.DropDownItems[ii].Text.IndexOf(popeName) != -1)//设置状态
                            {
                                tsdd1.DropDownItems[ii].Enabled = popeState;
                            }
                            ToolStripDropDownItem tsdd2 = (ToolStripDropDownItem)tsdd1.DropDownItems[ii];//二级菜单的下级集合
                            if (tsdd2.DropDownItems.Count > 0 && tsdd2.HasDropDownItems)//判断是否有三级菜单
                            {
                                for (int iii = 0; iii < tsdd2.DropDownItems.Count; iii++)//三级菜单
                                {
                                    if (tsdd2.DropDownItems[iii].Text.IndexOf(popeName) != -1)//设置状态
                                    {
                                        tsdd2.DropDownItems[iii].Enabled = popeState;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            #endregion
            #region 第三步 添加 treeView 中的菜单
            for (int i = 0; i < msp_mainMenu.Items.Count; i++)//一级菜单
            {
                TreeNode tn1 = new TreeNode(msp_mainMenu.Items[i].Text.Substring(0,msp_mainMenu.Items[i].Text.IndexOf("(")));
                if (msp_mainMenu.Items[i].Enabled == true)//判断状态是否能用,能则加
                {
                    tv_menu.Nodes.Add(tn1);
                }
                else
                { continue; }//状态为不能用时不再检测子级

                ToolStripDropDownItem tsdd1 = (ToolStripDropDownItem)msp_mainMenu.Items[i];//一级菜单的下级集合
                if (tsdd1.HasDropDownItems && tsdd1.DropDownItems.Count > 0)//判断是否有二级菜单
                {
                    for (int ii = 0; ii < tsdd1.DropDownItems.Count; ii++) //二级菜单
                    {
                        TreeNode tn2 = new TreeNode(tsdd1.DropDownItems[ii].Text.Substring(0,tsdd1.DropDownItems[ii].Text.IndexOf("(")));
                        if (tsdd1.DropDownItems[ii].Enabled == true)//判断状态是否能用,能则加
                        {
                            tn1.Nodes.Add(tn2);
                        }
                        else
                        {
                            continue;//状态为不能用时不再检测子级
                        }
                        ToolStripDropDownItem tsdd2 = (ToolStripDropDownItem)tsdd1.DropDownItems[ii];//二级菜单的下级集合
                        if (tsdd2.DropDownItems.Count > 0 && tsdd2.HasDropDownItems)//判断是否有三级菜单
                        {
                            for (int iii = 0; iii < tsdd2.DropDownItems.Count; iii++)//三级菜单
                            {
                                TreeNode tn3 = new TreeNode(tsdd2.DropDownItems[iii].Text.Substring(0,tsdd2.DropDownItems[iii].Text.IndexOf("(")));
                                if (tsdd2.DropDownItems[iii].Enabled == true)
                                {
                                    tn2.Nodes.Add(tn3);
                                }
                            }
                        }
                    }
                }
            }

            //展开所有
            tv_menu.ExpandAll();
            tv_menu.SelectedNode = null;
            #endregion
            #region 第四步 判断 ToolStrip 的菜单
            if (人事档案管理ToolStripMenuItem.Enabled == false)
            {
                btn_StuView.Enabled = false;
            }
            if (人事资料查询ToolStripMenuItem.Enabled == false)
            {
                btn_Stufind.Enabled = false;
            }
            if (通讯录ToolStripMenuItem.Enabled == false)
            {
                btn_AddressBook.Enabled = false;
            }
            if (日常记事ToolStripMenuItem.Enabled == false)
            {
                btn_Notepad.Enabled = false;
            }
            #endregion
            if (人事档案管理ToolStripMenuItem.Enabled == true)
            {
                P_haveDAAccess = true;
            }
            else
            {
                P_haveDAAccess = false;
            }

        }
        #region 根据所选菜单显示不同窗体
        private void 民族类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                                     //参数为 菜单的汉字部分
           FormsControls.ShowSubForm(sender.ToString().Substring(0,sender.ToString().IndexOf("(")));
        }

        private void 职工类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 文件程度设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 政治面貌设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 部门类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 工资类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 职务类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 职称类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 奖惩类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 记事本类别设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 员工生日提醒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 员工合同提醒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 人事档案管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 人事资料查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 人事资料统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 日常记事ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 备份还原数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 清空数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

       

        private void 帮助HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void btn_StuView_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString());
        }

        private void btn_Stufind_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString());
        }

        private void btn_HT_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString());
        }

        private void btn_AddressBook_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString());
        }

        private void btn_Notepad_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString());
        }
        private void 提醒设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }
       

       
       

        private void 重新登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 用户设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 系统退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void tv_menu_DoubleClick(object sender, EventArgs e)
        {
            FormsControls.ShowSubForm(tv_menu.SelectedNode.Text); 
        }


        private void 员工通讯录YToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }


        private void 个人通讯录GToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //参数为 菜单的汉字部分
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }


        private void tmr_showTime_Tick(object sender, EventArgs e)//显示时间
        {
            tssl_time.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }

        private void 系统帮助HHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }

        private void 关于本软件AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormsControls.ShowSubForm(sender.ToString().Substring(0, sender.ToString().IndexOf("(")));
        }
#endregion

    }
}