from flask import render_template, url_for, flash, redirect, request
from flaskblog import app, db, bcrypt
from flaskblog.forms import RegistrationForm, LoginForm
from flaskblog.models import User, Post
from flask_login import login_user, current_user, logout_user, login_required


posts = [

    {
        'author': 'Jane Doe',
        'title': 'Blog Post 2',
        'content': 'Second post content',
        'date_posted': 'April 21, 2018'
    }
]

accounts = [
    {
        'User': 'Luis Usseglio',
        'Account_ID': 'Account Number: 00126654',
        'Type': 'Checking',
        'date_posted': 'Since, November 11, 2019'
    },
    {
        'User': 'Luis Usseglio',
        'Account_ID': 'Account Number: 002154154',
        'Type': 'Savings',
        'date_posted': 'Since, November 12, 2019'
    }

]

transactions = [
    {
        'TransactionID': '1',
        'AccountId': '00126654',
        'ProcessingDate': '05/01/19',
        'Balance': '5,000.00',
        'CRorDR': '',
        'Amount': '',
        'Description': '',
    },
    {
        'TransactionID': '2',
        'AccountId': '00126654',
        'ProcessingDate': '05/02/19',
        'Balance': '4,998.00',
        'CRorDR': 'DR',
        'Amount': '$2.00',
        'Description': 'Starbucks',
    },
    {
        'TransactionID': '3',
        'AccountId': '00126654',
        'ProcessingDate': '05/04/19',
        'Balance': '5,798.00',
        'CRorDR': 'CR',
        'Amount': '$800.00',
        'Description': 'Payroll',
    }
]


@app.route("/")
@app.route("/home")
def home():
    return render_template('home.html', posts=posts)


@app.route("/about")
def about():
    return render_template('about.html', title='About')

@app.route("/contact")
def contact():
    return render_template('contact.html', title='Contact')


@app.route("/register", methods=['GET', 'POST'])
def register():
    if current_user.is_authenticated:
        return redirect(url_for('home'))
    form = RegistrationForm()
    if form.validate_on_submit():
        hashed_password = bcrypt.generate_password_hash(form.password.data).decode('utf-8')
        user = User(username=form.username.data, email=form.email.data, password=hashed_password)
        db.session.add(user)
        db.session.commit()
        flash('Your account has been created! You are now able to log in', 'success')
        return redirect(url_for('login'))
    return render_template('register.html', title='Register', form=form)


@app.route("/login", methods=['GET', 'POST'])
def login():
    if current_user.is_authenticated:
        return redirect(url_for('home'))
    form = LoginForm()
    if form.validate_on_submit():
        user = User.query.filter_by(email=form.email.data).first()
        if user and bcrypt.check_password_hash(user.password, form.password.data):
            login_user(user, remember=form.remember.data)
            next_page = request.args.get('next')
            return redirect(next_page) if next_page else redirect(url_for('home'))
        else:
            flash('Login Unsuccessful. Please check email and password', 'danger')
    return render_template('login.html', title='Login', form=form)


@app.route("/logout")
def logout():
    logout_user()
    return redirect(url_for('home'))


@app.route("/account")
@login_required
def account():
    return render_template('account.html', title='Account', accounts=accounts)

@app.route("/transaction")
@login_required
def transaction():
    return render_template('transaction.html', title='Transaction', transactions=transactions)
