
export { run }
function run(names, code, ...__props) {
    try {
        return new Function(...names, code)(...__props)
    }
    catch (e) {
        console.error(e)
    }
}

