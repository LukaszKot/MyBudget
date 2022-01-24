let component = $(".category-component");
if (component != null && component.length !== 0)
{
    component.click("focus",(e)=>{
        $.ajax({
            url: "/api/selects/categories/" + "es",
            success: function (data)
            {
                console.log(data);
            }
        })
        
    })
}