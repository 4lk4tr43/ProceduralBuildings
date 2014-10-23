module Program

open System.Windows.Forms
open System.Drawing

open Screen

let pen = new Pen(Color.Green, 5.0f)

let random = System.Random(0)
let number_of_parameters_per_rect = 3
let number_of_rects = 20

let sparse = 500.0
let biggest_rect = 800.0
let rectangles : seq<Rectangle> = seq { 
    for i in 1.0..double(number_of_rects) ->
        new Rectangle(
            int(random.NextDouble() * sparse), 
            int(random.NextDouble() * sparse),
            int(biggest_rect/i*random.NextDouble()),
            int(biggest_rect/i*random.NextDouble()) 
    )}

let form = new PaintForm(1500.0, 1000.0)    
form.Text <- "Canvas"
form.StartPosition <- FormStartPosition.CenterScreen
form.Paint.Add(fun context ->
    for i in rectangles do
        context.Graphics.DrawRectangle(pen, i)
    )
    
let timer = new System.Timers.Timer(3000.0)
timer.Elapsed.Add(fun e -> 
    form.Invalidate()
    )
timer.Start()

Application.Run(form)