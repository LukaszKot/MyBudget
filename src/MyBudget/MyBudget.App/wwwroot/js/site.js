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
            name: "",
            isNew: false
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
        let existingCategory = categories != null && categories.length >0 ? categories.filter(x => x.name === e.target.value)[0] : null
        this.setState({
            choosen: {
                id: existingCategory != null ? existingCategory.id : "",
                name: e.target.value,
                isNew: existingCategory == null && e.target.value !== ""
            },
            searchResult: categories == null ? [] : categories
        })
    }
    
    async addClick()
    {
        console.log("add: ", this.state.choosen.name)
    }
    
    update()
    {
        $(this.domElement.find(".category-list")).remove()
        this.domElement.unbind()
        this.domElement.on("input",(e)=>this.onInput(e))
        $(this.domElement.find(".category-input")[0]).val(this.state.choosen.name)
        let categoriesList = $("<div></div>").addClass("category-list");
        if(this.state.searchResult.length > 0)
        {
            let categoriesElements = this.state.searchResult.map(x =>
                $("<div></div>")
                    .addClass("category-list-element")
                    .text(x.name)
                    .click(()=>{
                        this.setState({ choosen: { id: x.id, name: x.name, isNew: false }, searchResult: []})
                    })

            )
            categoriesList.append(categoriesElements);
        }
        this.domElement.append(categoriesList)
        
        $(this.domElement.find(".add-category")).remove()
        if(this.state.choosen.isNew)
        {
            let categoryButton = $("<div></div>")
                .addClass("add-category")
                .text("+")
                .on("click", ()=>{
                    this.addClick()
                });
            this.domElement.append(categoryButton);
        }
    }
}
let components = []
let categoryComponents = $(".category-component");
for(let i=0; i<categoryComponents.length; i++)
{
    components.push(new SelectSearch(categoryComponents[i]))
}