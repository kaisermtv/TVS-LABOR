

! function (a) {                    //     ! Khai báo 1 hàm chức năng  || Mặc định  là undefined : chưa xác định , nhưng ta có thể làm nó trả về true

    function b(b, c) {              
        this.$element = a(b), this.settings = a.extend({}, d, c), this.init()
    }   
    var c = "searchable",                               //    khai báo thuộc tính mới như là ' có thể tìm kiếm '
        d = {
            selector: "tbody tr",                       //    Đối tượng phần tử là các dòng trong bảng , là đối tượng được chọn
            childSelector: "td",                        //      Xác định bộ chọn con  trong bộ chọn trên , ta sẻ tìm trong các thẻ td trong phần tử cha tr/tbody bên trên
            searchField: "#search",                     //      Id của ô tìm kiếm
            striped: !1,                                //      sọc ??
            oddRow: { 'background-color': '#f5f5f5' },  // dòng lẻ, duy nhất thì style là ...
            evenRow: { 'background-color': '#fff' },    // dòng giống nhau thì
            hide: function (a) {
                a.hide()                        
            },
            show: function (a) {
                a.show()                                // 
            },
            searchType: "default"                       // xác định kiểu tìm kiếm : fuzzy' : tương tự  'strict' :chính xác ;  'default' : trung bình
        };
    b.prototype = {
        init: function () {                             // khỏi tạo
            this.$searchElems = a(this.settings.selector, this.$element),           //     
            this.$search      =  a(this.settings.searchField),
            this.matcherFunc = this.getMatcherFunction(this.settings.searchType),
            this.bindEvents(),
            this.updateStriping()
        },
        bindEvents: function () {
            var b = this;
            this.$search.on("change keyup", function () {
                b.search(a(this).val()), b.updateStriping()
            }), "" !== this.$search.val() && this.$search.trigger("change")
        },
        updateStriping: function () {
            var b = this,
                c = ["oddRow", "evenRow"],
                d = this.settings.selector + ":visible";
            this.settings.striped && a(d, this.$element).each(function (d, e) {
                a(e).css(b.settings[c[d % 2]])
            })
        },
        search: function (b) {                                                                                  // tìm kiếm
            var c, d, e, f, g, h, i, j;                                                                         // 
            if (0 === a.trim(b).length) return this.$searchElems.css("display", ""), void this.updateStriping();            //  nếu nội dung giống y hệt  thì gọi tới thuộc tính display
            for (d = this.$searchElems.length, c = this.matcherFunc(b), i = 0; d > i; i++) {                                // ??? 
                for (h = a(this.$searchElems[i]), e = h.find(this.settings.childSelector), f = e.length, g = !0, j = 0; f > j; j++)
                    if (c(a(e[j]).text())) {
                        g = !1;
                        break
                    }
                g === !0 ? this.settings.hide(h) : this.settings.show(h)                            // đúng thì hiện ,sai thì ẩn đi
            }
        },
        getMatcherFunction: function (a) {                                          
            return "fuzzy" === a ? this.getFuzzyMatcher : "strict" === a ? this.getStrictMatcher : this.getDefaultMatcher       // Chọn kiểu tìm kiếm
        },
        getFuzzyMatcher: function (a) {                              // lấy vị trí giống kiểu gần giống
            var b, c = a.split("").reduce(function (a, b) {
                return a + "[^" + b + "]*" + b                          //  
            });
            return b = new RegExp(c, "gi"),
                function (a) {
                    return b.test(a)
                }
        },
        getStrictMatcher: function (b) {                                     // lấy vị trí giống kiểu chính xác
            return b = a.trim(b),
                function (a) {
                    return -1 !== a.indexOf(b)
                }
        },
        getDefaultMatcher: function (b) {                                       // lấy vị trí giống kiểu thông thường
            return b = a.trim(b).toLowerCase(),
                function (a) {
                    return -1 !== a.toLowerCase().indexOf(b)
                }
        }
    }, a.fn[c] = function (d) {
        return this.each(function () {
            a.data(this, "plugin_" + c) || a.data(this, "plugin_" + c, new b(this, d))
        })
    }
}(jQuery, window, document);