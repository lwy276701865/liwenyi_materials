// pages/index/index.js
Page({
  /**
   * 页面的初始数据
   */
  data: {
plain1:false,
plain2:true,
    color: " #F5F5DC",
questionReal:
[   
    "点击选题开始真心话吧！", "最欣赏自己哪个部位？对自己那个部位最不满意", "说出同寝室的人最让你受不了的习惯", "如果让你kiss现场的某一位异性，你会选择谁，为什么", "如果让你从现场找一位gg/mm的话，你会选择谁？给出三个理由", "如果明天是世界末日，你现在最想做的是什么", "要是妈妈和mm同时掉到水里会救谁先呢", "从小到大最丢脸出丑的事情是什么", "和多少异性有过非恋爱的暧昧关系", "你通常用那只指头挖鼻子", "现在心里最在意的异性叫什么名字", "每天睡觉前都会想起的人是谁", "谈过几次恋爱", "今天穿什么颜色的内裤", "身上哪个部位最敏感", "如果有一天我对你说我爱上你了，你怎么办", "你的初吻是几岁在什么地方被什么人夺去的", "大学一共挂过几门课", "如果让你选择做一个电影中的角色，你会选谁呢？", "如果请你从在座的里面选一位做你的男女朋友,你会选谁?", "哪个颜色的内衣最多？ 今天穿什么颜色？", "无聊的时候一般做什么？", " 会经常便秘吗?", "上次哭是什么时候？","你身上有没有胎记？长在什么地方，什么形状？"
],
    questionAdventure:
    [
        "点击选题开始大冒险吧！", " 表演希瑞：“我叫阿多拉，希曼的亲妹妹。这是顺风马，我的坐骑。我有一个不为人知的秘密，当我抽出剑叫道：“赐予我力量吧，我是希瑞！” 只有三个人知道这个秘密，他们是：希望之光，拉兹 夫人，和考尔。我和其他的朋友们一道，为解救以希利亚，与罪恶的霍达克进行着战斗！” ", "男生单腿下 跪，女生伸手，男生亲女生手背；", "男生将女生逼角落，壁咚女生，两人深情对视10秒", "到街上大喊“卖拖鞋啦～2块一双，买一送3” ", "在陌生人面前背诵一首古诗", "背一位异性绕场一周 ", "唱青藏高原最后一句", "做一个大家都满意的鬼脸 ", "做自己最性感、最妩媚的表情或动作", "蹲在凳子上作便秘状 ", "深情的吻墙10秒 ", "模仿脑白金广告，边唱边跳 ", "对陌生人美眉挤眉弄眼 ", "跳肚皮舞", "对外大喊我是 猪", "选一个男生 一边捶他的胸一边说： 你好讨厌哦 ", "站起來,大喊“我是超人, 我要回家了！”", "对窗外大喊“我好寂寞啊”","说一句绕口令 "
    ],
randomReal:0,
randomAdventure:0
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
  },
  gotomyStart:function()
  {
    
wx.navigateTo({
  url: 'myStart',
  success: function(res) {},
  fail: function(res) {},
  complete: function(res) {},
})
  } ,
setPlain1:function()
{
  
  this.setData({
    plain1:false, 
    plain2:true ,
    color:" #F5F5DC",
    randomReal: 0
  })
},
  setPlain2: function () {
this.setData
(
  {
    plain1:true,
    plain2:false,
      color: "#FFE4B5",
      randomAdventure: 0
  }
)    
  },
  getRandomReal: function () {
    var a =Math.floor(Math.random()*(this.data.questionReal.length-1))+1;
    this.setData({
      randomReal: a
    })
  },
getRandomAdventure:function()
{
  var b = Math.floor(Math.random() * (this.data.questionAdventure.length - 1)) + 1;
  this.setData({
    randomAdventure: b
  })
},
  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})