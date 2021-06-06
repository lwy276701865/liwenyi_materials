using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace 人事管理系统_GSJ
{
    class FormsControls
    {
        
        /// <summary>
        /// 根据不同的参数显示相应窗体
        /// </summary>
        /// <param name="formSign">窗体的标识</param>
        public static void ShowSubForm(string formSign)
        {
            #region 基础数据
            if (formSign == "民族类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "职工类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "文化程度设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "政治面貌设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "部门类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "工资类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "职务类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "职称类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "奖惩类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            else if (formSign == "记事本类别设置")
            {
                Frm_JiBen frm_jb = new Frm_JiBen();
                frm_jb.Text = formSign;
                frm_jb.ShowDialog();
                frm_jb.Dispose();
            }
            #endregion
            #region 员工信息提醒
            else if (formSign == "员工生日提示")
            {
                Frm_TiShi frm_ts = new Frm_TiShi();
                frm_ts.Text = formSign;
                frm_ts.ShowDialog();
                frm_ts.Dispose();
            }
            else if (formSign == "员工合同提示")
            {
                Frm_TiShi frm_ts = new Frm_TiShi();
                frm_ts.Text = formSign;
                frm_ts.ShowDialog();
                frm_ts.Dispose();
            }
           
            #endregion
            #region 人事管理
            else if (formSign == "人事档案管理")
            {
                Frm_DangAn frm_da = new Frm_DangAn();
                frm_da.Text = formSign;
                frm_da.ShowDialog();
                frm_da.Dispose();
            }
            else if (formSign == "人事资料查询")
            {
                Frm_ChaZhao frm_cz = new Frm_ChaZhao();
                frm_cz.Text = "人事资料查询";
                frm_cz.ShowDialog();
                frm_cz.Dispose();
            }
            else if (formSign == "人事资料统计")
            {
                Frm_TongJi frm_tj = new Frm_TongJi();
                frm_tj.Text = formSign;
                frm_tj.ShowDialog();
                frm_tj.Dispose();
            }
            #endregion
            #region 备忘记录
            else if (formSign == "日常记事")
            {
                Frm_JiShi frm_js = new Frm_JiShi();
                frm_js.Text = formSign;
                frm_js.ShowDialog();
                frm_js.Dispose();

            }
            else if (formSign == "员工通讯录")
            {
                Frm_TongXunLu frm_txl = new Frm_TongXunLu();
                frm_txl.Text = formSign;
                frm_txl.ShowDialog();
                frm_txl.Dispose();

            }
            else if (formSign == "个人通讯录")
            {
                Frm_TongXunLu frm_txl = new Frm_TongXunLu();
                frm_txl.Text = formSign;
                frm_txl.ShowDialog();
                frm_txl.Dispose();

            }
            #endregion
            #region 数据库维护
            else if (formSign == "备份/还原数据库")
            {
                Frm_BeiFenHuanYuan frm_bfhy = new Frm_BeiFenHuanYuan();
                frm_bfhy.Text = formSign;
                frm_bfhy.ShowDialog();
                frm_bfhy.Dispose();
            }
            else if (formSign == "清空数据库")
            {
                Frm_QingKong frm_qk = new Frm_QingKong();
                frm_qk.Text = formSign;
                frm_qk.ShowDialog();
                frm_qk.Dispose();
            }
            #endregion
            #region 工具管理
            else if (formSign == "计算器")
            {
                try
                {
                    System.Diagnostics.Process.Start("calc.exe");
                }
                catch 
                {
                    
                    
                }
            }
            else if (formSign == "记事本")
            {
                try
                {
                    System.Diagnostics.Process.Start("notepad.exe");
                }
                catch 
                {
                    
                   
                }
            }
            #endregion
            #region 系统管理 和帮助
            else if (formSign == "用户设置")
            {
                Frm_XiuGaiYongHu frm_xgyh = new Frm_XiuGaiYongHu();
                frm_xgyh.Text = formSign;
                frm_xgyh.ShowDialog();
                frm_xgyh.Dispose();
            }
            else if (formSign == "重新登录")
            {
                Application.Restart();
            }
            else if (formSign == "退出系统")
            {
                Application.Exit();
            }
            
            else if (formSign == "显示提醒")
            {
                Frm_TiXing frm_tx = new Frm_TiXing();
                frm_tx.ShowDialog();
                frm_tx.Dispose();
            }
            else if(formSign=="关于本软件")
            {
                FrmAbout frma = new FrmAbout();
                frma.ShowDialog();
                frma.Dispose();
            }
            else if (formSign == "系统帮助")
            {
                try
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\企业人事管理系统使用说明书.doc");
                }
                catch 
                {
                    
                    
                }
            }
            #endregion
        }
    }
}
