// pages/index/index.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    region: ['四川省', '成都市', '新都区'],
    now: ''
  },
  changeRegion: function (e) {
    this.setData({
      region: e.detail.value
    })
    this.getWeater(); //更新天气
  },
  getWeater:function()
  {
    var that = this;//this不可以直接在wxAPI函数内部使用
    wx.request({
      url: 'https://free-api.heweather.net/s6/weather/now?',
      data:
      {
        location:that.data.region[2],
        key:'1c2af2ab078049d1a82c04b45d1c0f6b'
      },
      success:function(res)
      {
        console.log(res.data);
        that.setData({ now: res.data.HeWeather6[0].now })
      }
    })
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
this.getWeater();
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