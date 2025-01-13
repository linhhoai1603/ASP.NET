// Toggle Password Visibility
function togglePassword(inputId) {
  const input = document.getElementById(inputId);
  const icon = document.querySelector(`#${inputId} + i`);
  
  // Toggle the type attribute
  input.type = input.type === 'password' ? 'text' : 'password';
  
  // Change icon based on visibility
  icon.classList.toggle('fa-eye');
  icon.classList.toggle('fa-eye-slash');
}

// Handle Login
function handleLogin(event) {
  event.preventDefault();
  
  const phone = document.getElementById('login-phone').value;
  const password = document.getElementById('login-password').value;
  const otp = document.getElementById('login-otp').value;

  if (!otp) {
      alert('Vui lòng nhập mã OTP.');
      return;
  }

  console.log('Logging in with:', { phone, password, otp });
  alert('Đăng nhập thành công!');
}

// Request OTP
function requestOtp() {
  const phone = document.getElementById('login-phone').value;

  if (!phone) {
      alert('Vui lòng nhập số điện thoại.');
      return;
  }

  console.log('Requesting OTP for phone:', phone);
  alert('Mã OTP đã được gửi tới số điện thoại của bạn.');
}
