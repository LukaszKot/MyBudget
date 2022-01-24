var restClient = {
    getCategories: (search) =>{
        return new Promise((resolve, reject)=>{
            $.ajax({
                url: "/api/selects/categories/" + search,
                success: function (data)
                {
                    resolve(data.categories)
                },
                error: function ()
                {
                    reject()
                }
            })
        })
    }
}

class SelectSearch
{
    state = {
        choosen: {
            id: "",
            name: ""
        },
        searchResult: []
    }
    
    constructor(domElement) {
        this.domElement=$(domElement)
        this.update()
    }
    
    setState(newState)
    {
        this.state = newState;
        console.log(this.state)
        this.update();
    }
    
    async onInput(e)
    {
        let categories = await restClient.getCategories(e.target.value)
            .catch(()=>{})
        this.setState({
            choosen: {
                id: "",
                name: e.target.value
            },
            searchResult: categories == null ? [] : categories
        })
    }
    
    update()
    {
        $(this.domElement.find(".category-list")).remove()
        this.domElement.unbind()
        this.domElement.on("input",(e)=>this.onInput(e))
        let categoriesList = $("<div></div>").addClass("category-list");
        if(this.state.searchResult.length > 0)
        {
            let categoriesElements = this.state.searchResult.map(x =>
                $("<div></div>")
                    .addClass("category-list-element")
                    .text(x.name)
                    .click(()=>{
                        this.setState({ choosen: x, searchResult: []})
                    })

            )
            categoriesList.append(categoriesElements);
        }
        this.domElement.append(categoriesList)
    }
}
let components = []
let categoryComponents = $(".category-component");
for(let i=0; i<categoryComponents.length; i++)
{
    components.push(new SelectSearch(categoryComponents[i]))
}