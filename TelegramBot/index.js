const Telegraf = require('telegraf');
const Markup = require('telegraf/markup');
const sql = require('mssql');

(async () => {
    try {
        // make sure that any items are correctly URL encoded in the connection string
        await sql.connect('mssql://softlistdbadmin:Vfkbyrf98@softlist.database.windows.net/hack2020_4?encrypt=true');
        const result = await sql.query`select * from Courses where id = 1`;
        console.dir(result);
    } catch (err) {
        console.log(err);
    }
})();

const bot = new Telegraf('838759197:AAH3Fb4KFYqtmAgomB_L724gQ4XFaWN3j1Y');

// bot.use(async (ctx, next) => {
//     const result = await getCategories();
//     console.dir(result);
//     ctx.reply('Custom buttons keyboard', Markup
//         .keyboard([
//             ['🔍 Search', '😎 Popular'], // Row1 with 2 buttons
//             ['☸ Setting', '📞 Feedback'], // Row2 with 2 buttons
//             ['📢 Ads', '⭐️ Rate us', '👥 Share'] // Row3 with 3 buttons
//         ])
//         .oneTime()
//         .resize()
//         .extra());
// })

bot.start((ctx) => ctx.reply('Welcome to Schedule Bot for Hackaton2020 Team 4!'));
bot.help((ctx) => ctx.reply('Натискайне на клавіші клавіатури які вам були надіслані щоб дізнатись про розклад курсу.'));
bot.on('sticker', (ctx) => ctx.reply('👍'));
bot.hears('hi', (ctx) => ctx.reply('Hey there'));
bot.on('message', async (ctx) => {
    try {
        const result = await sql.query(`SELECT Modules.Title, Modules.DateTimeStart FROM Courses JOIN Modules on Courses.ID = Modules.CourseID WHERE Courses.Title = '${ctx.message.text}';`);
        if (result.recordset.length < 1) sendMessageWithKeyboard(ctx, 'Не можемо відповісти на ваше повідомлення, напишіть /help щоб дізнатися про всі комманди бота.');
        else {
            let message = `Розклад на курс ${ctx.message.text}\n`;
            for (let i = 0; i < result.recordset.length; i++) {
                message += `${i + 1}. ${result.recordset[i].Title} - ${(result.recordset[i].DateTimeStart.getDate() < 10) ? '0' : ''}${result.recordset[i].DateTimeStart.getDate()}.${((result.recordset[i].DateTimeStart.getMonth() + 1) < 10) ? '0' : ''}${result.recordset[i].DateTimeStart.getMonth() + 1}.${result.recordset[i].DateTimeStart.getFullYear()} ${((result.recordset[i].DateTimeStart.getHours() - 2) < 10) ? '0' : ''}${result.recordset[i].DateTimeStart.getHours() - 2}:${(result.recordset[i].DateTimeStart.getMinutes() < 10) ? '0' : ''}${result.recordset[i].DateTimeStart.getMinutes()}\n`;
            }
            sendMessageWithKeyboard(ctx, message);
        }
    } catch (error) {
        sendMessageWithKeyboard(ctx, 'Не можемо відповісти на ваше повідомлення, напишіть /help щоб дізнатися про всі комманди бота.');
        console.log(error);
    }
});

bot.launch();

async function getCategories() {
    return await sql.query`SELECT Courses.Title FROM Courses`;
}

async function sendMessageWithKeyboard(ctx, message) {
    const categories = await getCategories();
    console.dir(categories.recordset);

    const categoriesArray = [];
    for (let i = 0; i < categories.recordset.length; i++) {
        categoriesArray.push([categories.recordset[i].Title]);
    }

    ctx.reply(message, Markup
        .keyboard(categoriesArray)
        .oneTime()
        .resize()
        .extra());
}

