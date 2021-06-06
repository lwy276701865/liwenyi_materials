// pages/index/myStart.js
var _animation;
var _animationIndex;
const _ANIMATION_TIME = 500;
Page({

  /**
   * 页面的初始数据
   */
  data: {
    animation: ''
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) 
  {

  },
myTouch:function()
{

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
    _animation = wx.createAnimation({
      duration: _ANIMATION_TIME,
      timingFunction: 'linear', // "linear","ease","ease-in","ease-in-out","ease-out","step-start","step-end"
      delay: 0,
      transformOrigin: '50% 50% 0'
    })

  },
  rotateAni: function () {
 var a=Math.abs( Math.random()*3000+360)
    _animation.rotate(a).step()
    this.setData({
      animation: _animation.export()
    })
 
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
