var HomeControl = {

    init: function () {
        HomeControl.resgisterEvent();
    },

    resgisterEvent: function () {
        $('#formOder').validate({
            rules:
            {
                txtName:
                {
                    required: true,
                    minlength: 2,
                    maxlength: 100

                },
                txtPhone:
                {
                    required: true,
                    digits: true,
                    minlength: 1,
                    maxlength: 10
                },
                txtEmail:
                {
                    email: true
                },
                txtQuantity:
                {
                    required: true,
                    number: true,
                    digits: true,
                    min: 1,


                }
            },
            messages:
            {
                txtName:
                {
                    required: "Vui lòng điền Tên !",
                    minlength: "Tên phải lớn hơn 2 ký tự !",
                    maxlength: "Tên không lớn hơn 100 ký tự !"

                },
                txtPhone:
                {
                    required: "Vui lòng điền số điện thoại !",
                    digits: "Số điện thoại phải là số !",
                    maxlength: "Số điện thoại không lớn hơn 10 ký tự !",
                    min: "Số điện thoại phải lớn hơn 1 ký tự !"
                },
                txtEmail:
                {
                    email: "Đây không phải là Email vui lòng kiểm tra lại !"
                },
                txtQuantity:
                {
                    required: "Vui lòng điền số lượng đặt hàng",
                    number: "Số lượng đặt hàng phải lớn hơn 0",
                    digits: "Số lượng đặt hàng phải là số",
                    min: "Số lượng đặt hàng phải lớn hơn 0",
                }
            }
        });

        $('#formContact').validate({
            rules:
            {
                txtNameC:
                {
                    required: true,
                    minlength: 2,
                    maxlength: 100
                },
                txtEmailC:
                {
                    required: true,
                    email: true,
                    minlength: 2

                },
                txtMessageC:
                {
                    required: true,
                    minlength: 5

                }

            },
            messages:
            {
                txtNameC:
                {
                    required: "Vui lòng điền Tên !",
                    minlength: "Tên không nhỏ hơn 2 ký tự",
                    maxlength: "Tên không hơn 100 ký tự"

                },
                txtEmailC:
                {
                    required: "Vui lòng điền Email !",
                    email: "Đây không phải Email !",
                    minlength: "Độ dài Email phải lớn hơn 2 ký tự",


                },
                txtMessageC:
                {
                    required: "Vui lòng nhập nội dung cần liên hệ !",
                    minlength: "Độ dài tin nhắn phải lớn hơn 5 ký tự"
                }
            }

        });

        $('#btnOder').off('click').on('click', function () {

            if ($('#formOder').valid()) {
                $('.loader').addClass("is-active");
                HomeControl.SendDataOder();
            }
        });


        $('#btnSend').off('click').on('click', function () {

            if ($('#formContact').valid()) {
                $('.loader').addClass("is-active");
                HomeControl.SenDataContact();

            }
        });

    },

    resetForm: function () {
        $('#txtNameC').val('');
        $('#txtEmailC').val('');
        $('#txtMessageC').val('');
    },

    resetFormOder: function () {
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtPhone').val('');
        $('#txtQuantity').val('');
    },

    SendDataOder: function () {
        $('#formOder').submit(function (e) {
            $('#btnOder').prop('disabled', true);
            e.preventDefault();
            name = $('#txtName').val();
            email = $('#txtEmail').val();
            phone = $('#txtPhone').val();
            quantity = $('#txtQuantity').val();

            var token = $("[name='__RequestVerificationToken']").val();

            $.ajax({
                url: '/Order/GetDataOder',
                data:
                {
                    __RequestVerificationToken: token,
                    Name: name,
                    Email: email,
                    Phone: phone,
                    Quantity: quantity
                },
                type: 'POST',
                dataType: 'JSON',
                success: function (response) {
                    if (response.status) {
                        $('#btnOder').prop('disabled', false);
                        $('.loader').removeClass("is-active");
                        window.location.href = "/";
                        HomeControl.resetFormOder();
                    }
                    else {
                        $('#btnOder').prop('disabled', false);
                        window.location.href = "/admin";
                    }
                },
                error: function (errorStatus) {
                    console.log(errorStatus);
                }
            });

        });

    }

}

HomeControl.init();