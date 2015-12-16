function formValidation() {
    $('#form').validate({
        rules: {
            Username: {
                required: true
            },
            Pwd: {
                required: true
            }
        },
        messages: {
            Username: {
                required: "请填写用户名"
            },
            Pwd: {
                required: "请填写密码"
            }
        }
    });
}
